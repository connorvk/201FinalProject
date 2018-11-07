using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterScript : MonoBehaviour {
    public enum Type
    {
        BLOB,
        Long,
        Char_Star
    }

    public bool status;
    public int currHP;
    public int maxHP;
    public int type;
    public List<monsterMove> moves;

	// Use this for initialization
	void Start () {
        if (!status)
        {
            //wild monster init
        }
        else if (status)
        {
            //player monster init
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
