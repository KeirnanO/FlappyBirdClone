using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour {


    public TMP_Text score;
    public TMP_Text tutorial;
    public TMP_Text tutorial2;
    public TMP_Text coins;
    
    private Movement player;

    private int intScore;
    private int intCoins;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
    }

    void Update ()
    {

        if(!player.IsPlaying() && Input.GetKeyDown("2"))
        {
            tutorial2.SetText("Press K to Fly");
        }


        if(player.IsPlaying() && !tutorial.text.Equals(""))
        {
            tutorial.SetText("");
            tutorial2.SetText("");
        }

        if(player.IsDead())
        {
            tutorial.SetText("Press R to Restart");
            tutorial2.SetText("Get Better");
        }

        //These are stored in variables incase they will be altered later
        intCoins = player.GetCoins();
        intScore = player.GetScore();

        coins.SetText("coins: " + intCoins);
        score.SetText(intScore.ToString());


	}



}
