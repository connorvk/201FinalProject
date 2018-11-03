using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
