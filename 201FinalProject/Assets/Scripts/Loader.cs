using System.Collections;
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
            Instantiate(GameManager.instance.player);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
