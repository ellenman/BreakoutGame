using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public Text highScoreText;
    public bool gameOver;
    public GameObject endViewPanel;
    public GameObject loadLevelPanel;

    public int numberOfBricks; //use this to find the number of bricks 

    public Transform[] levels;
    public int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //I will check if lives are available
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;

    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBricks() 
    {
        numberOfBricks--;
        if(numberOfBricks <=0)
        {
            //length -1 because we start from 0 
            if(currentLevel >= levels.Length - 1)
            {
                GameOver();
            }
            //we have another level 
            else
            {
                //activate the loading panel
                loadLevelPanel.SetActive(true);
                //we can edit the text we have in the load level panel because is the only component
                //we add two at the current level because we want the next level and also we start from 0
                //for example at the end of level 1 which is 0 we want to be shown level 2
                loadLevelPanel.GetComponentInChildren<Text>().text = "Loading Level" + (currentLevel + 2);
                //to freeze the game while the new level will come 
                gameOver = true;
                //load the level after a small amount of time 1.5
                Invoke ("LoadLevel", 1.5f);
            }
           
            
        
        }
    }

    public void LoadLevel()
    {
        currentLevel++;
        //position at 0,0
        Instantiate(levels[currentLevel], Vector2.zero, Quaternion.identity);
        //then we have to count again the bricks
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
        //remove from the screen the load level panel
        loadLevelPanel.SetActive(false);

    }

    public void GameOver()
    {
        gameOver = true;
        endViewPanel.SetActive(true);
        
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        //if the score is greater than the highscore then we have a new highscore
        if (score > highScore)
        {
            //save the new highscore as highscore
            PlayerPrefs.SetInt("HIGHSCORE", score);
            //update the highScore text
            highScoreText.text = "New High Score! " + score;
        }
        //if we didn't get a new highscore
        else
        {
            highScoreText.text = "HighScore: " + highScore + "\n" + "Can you get higher score?";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
      
    }

    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
