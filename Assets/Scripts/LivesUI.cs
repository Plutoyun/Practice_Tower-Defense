using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour { // Player's life display


    public Text LivesText;
	
	// Update is called once per frame
	void Update () {
        LivesText.text = PlayerStats.Lives.ToString(); //+ "LIVES";
	}
}
