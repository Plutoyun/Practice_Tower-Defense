using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//添加类 可以在成员的inspctor中显示属性

public class TurretBluePoint { //Turret kinds

    // match upgrade models for each turret
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab_1;
    public int upgradeCost_1;

    public GameObject upgradedPrefab_2;
    public int upgradeCost_2;

    //public int level=1;

    public int GetSellAmount() // Sell price
    {
        return cost / 2;
    }
}
