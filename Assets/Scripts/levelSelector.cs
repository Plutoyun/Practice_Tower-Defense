using UnityEngine;
using UnityEngine.UI;
public class levelSelector : MonoBehaviour {

    public string menuname = "Menu";
    public SceneFader scenefader;
    public Button[] LevelButtons;
    public static int LevelReached = 1;

    private void Start()
    {
        // int LevelReached = PlayerPrefs.GetInt("LevelReached",1);//Unity自置的功能用来存储int float等 会保留重新开始游戏时上次的数据（本地）
        LevelReached = 1;

        for (int i = 0; i < LevelButtons.Length; i++)
        {
           
            if (i > LevelReached-1)
            {
                LevelButtons[i].interactable = false;
            }
           
        }
    }

    public void Select(string LevelName)
    {
        scenefader.FadeTo(LevelName);
    }

    public void Menu()
    {
        scenefader.FadeTo(menuname);
    }
}
 