using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour { // Game over UI

    public SceneFader sceneFader;
    public string menuname = "Menu";

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//选取当前场景重新载入
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuname);
        //Debug.Log("MENU");
    }

}
