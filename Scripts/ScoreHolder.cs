using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHolder : MonoBehaviour {

    //total score
    int playerScore = 0;
    //score Text object
    public Text scoreText;

    //current enemies on map Text object
    public Text currentEnemies;
    //total enemies from start of level Text object
    public Text totalEnemies;

    int totalCount = 0;
    int currentCount = 0;

    GameObject[] gos;
    // Use this for initialization
    void Start () {
        scoreText.text = playerScore + "";

     
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        currentCount = totalCount = gos.Length;
        
        totalEnemies.text = "/" + totalCount;
        currentEnemies.text = ""+ totalCount;
    }
	
    public void UpdateScore(int points)
    {
        playerScore += points;
        scoreText.text = playerScore + "";

        UpdateEnemies();
    }

    public void UpdateEnemies()
    {
        currentCount--;
        currentEnemies.text = currentCount + "";
        Debug.Log("total : " + currentCount);

        if(currentCount == 0)
        {
            //if no enemies remain, level/game complete!

            //Application.Quit();


            //Application.LoadLevel("TimeMode");
            // SceneManager.LoadScene("InstructionsPage");
        }
    }
}
