using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeForce : MonoBehaviour {


    public Rigidbody2D rb;
    public int force;

    private Movement player;

    private int deathTime = 0;


	// Use this for initialization
	void Start ()
    {
        rb.AddForce(new Vector2(force*100, 0));
        player = FindObjectOfType<Movement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        if (!(player.IsDead()))
        {
            deathTime++;

            if (deathTime > 420f)
            {
                Destroy(this.gameObject);
            } 
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

	}
}
