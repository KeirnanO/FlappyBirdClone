using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveForce : MonoBehaviour {

    public new Rigidbody2D rb;
    public int force = -100;

    private Movement player;

    private int deathTime = 0;


    // Use this for initialization
    void Start()
    {
        rb.AddForce(new Vector2(force, 0));
        player = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

        if(rb.position.x == 29)
        {
            print(deathTime);
        }

        if ((player.IsDead()))
        {
            rb.velocity = new Vector2(0, 0);
        }

    }
}
