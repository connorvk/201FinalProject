﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject Player;

	// Use this for initialization
	void Awake ()
    {
        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
