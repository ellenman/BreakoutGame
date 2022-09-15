using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;

    public Transform paddle;

    public float speed;
    public Transform explosion;
    public GameManager gm;

    public Transform powerUp;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            //return so we can skip everything 
            return;
        }
        if(!inPlay)
        {
            transform.position = paddle.position;

        }
        if(Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("bottom"))
        {
            Debug.Log("Oups the bal hit the bottom of the screen!");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
           
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("brick"))
        {
            //get the brick script
            bricksScript brick = other.gameObject.GetComponent<bricksScript> ();
            if (brick.hitsUntilBreak > 1)
            {
                brick.BreakTheBrick();

            }
            else
            {
                //picks a number between 1-100
                int randomChance = Random.Range(1, 101);
                //10% changes to get a new life when breaking a break 
                if (randomChance < 10)
                {
                    Instantiate(powerUp, other.transform.position, other.transform.rotation);
                }
                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                //access the brick script to check the points

                gm.UpdateScore(brick.points);
                gm.UpdateNumberOfBricks();
                Destroy(other.gameObject);
            }
            //play the audio
            audio.Play();
        }
    }
}
