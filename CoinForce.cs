using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinForce : MonoBehaviour {

    public Rigidbody2D rb;
   
    private Movement player;

    private float time = 0f;


	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Movement>();

        rb.AddForce(new Vector2(-2, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(time >= 420f)
        {
            Destroy(this.gameObject);
        }

		if(player.IsDead())
        {
            rb.velocity = new Vector2(0, 0);
        }

        time++;
    }


}
