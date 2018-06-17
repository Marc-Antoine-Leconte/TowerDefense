using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint {

    public int cost;
    public int upgradeCost;

    public GameObject prefab_L01;
    public GameObject prefab_L02;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
