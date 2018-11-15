using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOnCollision : MonoBehaviour {

    private Renderer renderer;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        renderer = GetComponent<Renderer>();
        //renderer.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollision2D(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
            Debug.Log("collided");
    }

    // Update is called once per frame
    void Update ()
    {
	}
}
