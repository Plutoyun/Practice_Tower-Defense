using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string levelSelectname = "LevelSelect";
    public GameObject ui;
    public SceneFader sceneFader;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
	}

    public void Toggle()
    {
        if (Gamemanger.GameIsOver)
        {
            return;
        }
        ui.SetActive(!ui.activeSelf); //执行和自身active状态相反的状态 Executing a state opposite to its active state
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
            Time.timeScale = 1f;
    }

    public void Retry()
    {
        Toggle();
        // SceneManager.LoadScene("Main Scene");//SceneManager.GetActiveScene().buildIndex);//选取当前场景重新载入
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(levelSelectname);
        //SceneManager.LoadScene(menuname);
        //Debug.Log("MENU");
    } 
}
