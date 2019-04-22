using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {


    public Vector3 rotations = new Vector3(0, 0, 0);

    private Movement player;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }
    // Update is called once per frame
    void Update ()
    {

        if (!(rotations.z <= -80) && player.IsPlaying())
        {
            rotations.z -= 2;
            transform.Rotate(0,0,-2);
        }

    }
}
