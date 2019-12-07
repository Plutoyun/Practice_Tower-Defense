using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanger : MonoBehaviour { // Control game states

    public static bool GameIsOver;

    public GameObject GameOverUI;
    public GameObject CompleteLevelUI;

    void Start()
    {
        GameIsOver = false;
        WaveSpawner.EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update () {

        if (GameIsOver)
        {
            return;
        }

        /*//TEST
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }*/
        if (PlayerStats.Lives <=0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameOverUI.SetActive(true);
        GameIsOver = true;
        Debug.Log("GameOver!");
    }

    public void WinLevel()
    {
        GameIsOver = true;
        CompleteLevelUI.SetActive(true);
       
    }
}
