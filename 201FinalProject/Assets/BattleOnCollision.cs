using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOnCollision : MonoBehaviour {

    public GameObject Other;
    private Renderer renderer;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        renderer = GetComponent<Renderer>();
        //renderer.enabled = false;
        rb = GetComponent<Rigidbody2D>();
	}

    void OnCollisionStay2D(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Colliding");
        }
    }

    // Update is called once per frame
    void Update ()
    {
	}
}
