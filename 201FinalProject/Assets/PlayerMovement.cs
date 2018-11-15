using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    private float walkSpeed;
    public float curSpeed;
    private float maxSpeed;
    private Rigidbody2D rb;
    //TODO check structure for presentation
    public List<GameObject> Enemy;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        maxSpeed = curSpeed;
        // Move senteces
        rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("checking collision");
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Collide with enemy");
            //Load Battle Scene
            GameManager.instance.LoadBattleScene(GameManager.instance.mCurrentState);
        }
    }
}
