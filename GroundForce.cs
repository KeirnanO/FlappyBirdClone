using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundForce : MonoBehaviour {


    public new Rigidbody2D rb;
    public int force;

    private Movement player;

    // Use this for initialization
    void Start()
    {
        rb.AddForce(new Vector2(force * 10000, 0));
        player = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if ((player.IsDead()))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "end")
        {
            Destroy(this.gameObject);
        }
        if(collision.collider.tag == "Ground")
        {
            Physics2D.IgnoreLayerCollision(1,1);
        }
    }


}
