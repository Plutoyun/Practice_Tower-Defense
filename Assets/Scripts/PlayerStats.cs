using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money; 
    public int startMoney = 450;//Default money

    public static int Lives; 
    public int startLives = 20;//Defaulr life

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0; //Wave rounds
    }



}
