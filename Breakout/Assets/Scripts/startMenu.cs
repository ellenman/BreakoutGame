using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class startMenu : MonoBehaviour
{
    public Text highScoreText;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("HIGHSCORE") != 0)
        {
            //get the highscore from the player prefs
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HIGHSCORE");
        }
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }

    public void StartGame()
    {
        //load the sample scene when we press the start game button 
        SceneManager.LoadScene("Scenes/SampleScene");
    }


}
