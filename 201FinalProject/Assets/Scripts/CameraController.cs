using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject MainCharacter;
    private Vector3 offset;
	
    // Use this for initialization
	void Start ()
    {
        MainCharacter = GameManager.instance.player;
        offset = transform.position - MainCharacter.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = MainCharacter.transform.position + offset;
	}
}
