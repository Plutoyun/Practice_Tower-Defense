using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour { // Complete a level

    public SceneFader sceneFader;
    public string levelSelectname = "LevelSelect";
    public int LevelToUnlock = 2;
    public string NextLevel = "Level02";


    public void LevelSelect()
    {
        sceneFader.FadeTo(levelSelectname); //Load secene
        //Debug.Log("MENU");
    }

    public void Next()
     {
        // PlayerPrefs.SetInt("LevelReached", LevelToUnlock);
        levelSelector.LevelReached = LevelToUnlock; // Unlock
        sceneFader.FadeTo(NextLevel); // Load next scene
     }

    /*public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//选取当前场景重新载入
    }*/

}
