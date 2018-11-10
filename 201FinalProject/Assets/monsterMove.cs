using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class monsterMove {
    public string moveName;
    public int dmg;

    public monsterMove(string n, int d)
    {
        dmg = d;
        moveName = n;
    }
}
