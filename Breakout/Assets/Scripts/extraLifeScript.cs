using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraLifeScript: MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //we don't want to move it in x axis we want to move it only in y so -1 to go down 
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);
        //when the life goes at y=-6 destroy it 
        if(transform.position.y  < -6f)
        {
            //destroy the game object that the script is attached to
            Destroy(gameObject);
        }
    }
}
