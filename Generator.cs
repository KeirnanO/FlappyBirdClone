using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public Transform player2PreFab;
    public Transform spikePrefab;
    public Transform groundPrefab;
    public Transform cavePrefab;
    public Transform coinPreFab;

    private Movement player;
    private Movement2 player2;

    public float spikeSpawnTime = 0f;
    public float groundSpawnTime = 0f;
    public float coinSpawnTime = 0f;
    public float caveSpawnTime = 0f;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player2 == null)
        {
            if (!(player.IsDead()))
            {
                if (spikeSpawnTime >= 120f && player.IsPlaying())
                {
                    Instantiate(spikePrefab, new Vector3(10, (5 + Random.Range(-2, 4)), 5), Quaternion.Euler(0, 0, 0));
                    spikeSpawnTime = 0f;
                }

                if (coinSpawnTime >= 240f && player.IsPlaying())
                {
                    Instantiate(coinPreFab, new Vector3((13 + Random.Range(-1, 1)), (4 + Random.Range(-5, 3)), 5), Quaternion.Euler(0, 0, 0));
                    coinSpawnTime = 0f;
                }

                if (groundSpawnTime == 0f)
                {
                    Instantiate(groundPrefab, new Vector3(55, -5, 0), Quaternion.Euler(0, 0, 0));
                    groundSpawnTime = 393f;
                }

                if (Input.GetKeyDown("2"))
                {
                    Instantiate(player2PreFab, new Vector3(-7, 5, 10), Quaternion.Euler(0, 0, 0));
                    player2 = FindObjectOfType<Movement2>();
                }
            }
        }
        else
        {
            if (!(player.IsDead()) || !(player2.IsDead()))
            {
                if (spikeSpawnTime >= 120f && (player.IsPlaying() || player2.IsPlaying()))
                {
                    Instantiate(spikePrefab, new Vector3(10, (5 + Random.Range(-2, 4)), 5), Quaternion.Euler(0, 0, 0));
                    spikeSpawnTime = 0f;
                }

                if (coinSpawnTime >= 240f && (player.IsPlaying() || player2.IsPlaying()))
                {
                    Instantiate(coinPreFab, new Vector3((13 + Random.Range(-1, 1)), (4 + Random.Range(-5, 3)), 5), Quaternion.Euler(0, 0, 0));
                    coinSpawnTime = 0f;
                }

                if (groundSpawnTime == 0f)
                {
                    Instantiate(groundPrefab, new Vector3(55, -5, 0), Quaternion.Euler(0, 0, 0));
                    groundSpawnTime = 393f;
                }

            }
        }

        spikeSpawnTime += 1f;
        groundSpawnTime -= 1f;
        coinSpawnTime += 1f;

        
    }


}
