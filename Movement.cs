using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {


    public Rigidbody2D rb;
    public Transform player;

    public AudioClip jumpAudio;
    public AudioClip deathSound;
    public AudioClip pointSound;
    public AudioClip coinSound;

    public Rotation sprite;


    private bool isDead = false;
    private bool playing = false;

    private AudioSource source;

    public int score = 0;
    private int points = 0;
    private int coins;

    public float flySpeed = 350f;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        Physics2D.IgnoreLayerCollision(0, 0);


        rb.gravityScale = 0;
        
        coins = 0;


        
    }


    // Update is called once per frame
    void Update ()
    {
        if (!isDead && !IsPlaying())
        {
            if (Input.GetKeyDown("a"))
            {
                playing = true;
                rb.gravityScale = 2;
            }

        }
        else if (!isDead)
        {
            if (Input.GetKeyDown("a"))
            {
                source.PlayOneShot(jumpAudio);
                rb.velocity = Vector2.zero;
                rb.AddRelativeForce(new Vector2(0f, flySpeed));

                sprite.transform.Rotate(new Vector3(0, 0, (65 - sprite.rotations.z)));
                sprite.rotations.z = 65;
            }
        }

        if(isDead)
        {
            if(Input.GetKeyDown("r"))
            {
                player.SetPositionAndRotation(new Vector3(-7, 3), Quaternion.Euler(0,0,0));
                SceneManager.LoadScene(0);
                playing = true;
                isDead = false;
            }
        }

	}



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.rigidbody.tag == "point")
        {
            Destroy(collision.gameObject);

            source.PlayOneShot(pointSound);
            score++;
        }
        else if (collision.rigidbody.tag.Equals("Coin"))
        {
            Destroy(collision.gameObject);

            source.PlayOneShot(coinSound);
            coins++;
        }
        else
        {
            isDead = true;
            sprite.rotations.z = -100;
            source.PlayOneShot(deathSound);
        }
    }



    public bool IsDead()
    {
        return isDead;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetPoints()
    {
        return points;
    }

    public void NewPoints(int points)
    {
        this.points += points;
    }

    public bool IsPlaying()
    {
        return playing;
    }

    public void AddCoins(int coins)
    {
        this.coins += coins;
    }
    public int GetCoins()
    {
        return coins;
    }
}
