using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Loop : MonoBehaviour {
    
    public int iPlayer = 0;
    public int TimeBonus = 0;
    public float iTime = 1;

    public Text TimeText;
    public Text[] ScoreLabels = new Text[4];

    private PlayerSpawner m_Players;

    // Use this for initialization
    void Start () {
        iTime = 120;
        m_Players = FindObjectOfType<PlayerSpawner>();
        foreach (var ScoreLabel in ScoreLabels)
        {
            ScoreLabel.text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
        iTime = iTime - Time.deltaTime;
        string minutes = Mathf.Floor(iTime / 60).ToString("0");
        string seconds = (iTime % 60).ToString("00");
        if (iTime > 0)
        {
            TimeText.text = string.Format("{0}:{1}", minutes, seconds);
        }
        else
        {
            TimeText.text = "0";
        }

        for (int i = 0; i < 4; i++)
        {
            ScoreLabels[i].text = string.Format("Player {0}: {1}", i, m_Players.playerInstances[i].spawnedPlayer.points);
        }
        /*
        if (Score_P1 > 0)
        {
            P1Score.text = "Player 1: " + string.Format("{0}", Score_P1);
        }
        else
        {
            P1Score.text = " ";
        }
        if (Score_P2 > 0)
        {
            P2Score.text = "Player 2: " + string.Format("{0}", Score_P2);
        }
        else
        {
            P2Score.text = " ";
        }
        if (Score_P3 > 0)
        {
            P3Score.text = "Player 3: " + string.Format("{0}", Score_P3);
        }
        else
        {
            P3Score.text = " ";
        }
        if (Score_P4 > 0)
        {
            P4Score.text = "Player 4: " + string.Format("{0}", Score_P4);
        }
        else
        {
            P4Score.text = " ";
        }
        */

        if ( iTime <= 0 )
        {
            Application.Quit();
        }
    }

    public void ScoreBoard()
    {
        
    }

    public void TimetoPoints(int playerNumber)
    {
        var player = m_Players.playerInstances[playerNumber - 1].spawnedPlayer;
        
        if (iTime >= 96)
        {
            TimeBonus = 500;
        }
        else if (iTime >= 72)
        {
            TimeBonus = 400;
        }
        else if (iTime >= 48)
        {
            TimeBonus = 300;
        }
        else if (iTime >= 24)
        {
            TimeBonus = 200;
        }
        else
        {
            TimeBonus = 100;
        }

        player.points += TimeBonus;
    }

    public void Collectable ()
    {
        //iPlayer = m_Player.GetPlayer();
        //print(iPlayer);

        //if (iPlayer == 0)
        //{
        //    Score_P1 = Score_P1 + 100;
        //}
        //else if (iPlayer == 1)
        //{
        //    Score_P2 = Score_P2 + 100;
        //}
        //else if (iPlayer == 2)
        //{
        //    Score_P3 = Score_P3 + 100;
        //}
        //else if (iPlayer == 3)
        //{
        //    Score_P4 = Score_P4 + 100;
        //}
    }

    public void Trophy () {
        //iPlayer = m_Player.GetPlayer();

        //if (iPlayer == 0)
        //{
        //    Score_P1 = Score_P1 + 500;
        //}
        //else if (iPlayer == 1)
        //{
        //    Score_P2 = Score_P2 + 500;
        //}
        //else if (iPlayer == 2)
        //{
        //    Score_P3 = Score_P3 + 500;
        //}
        //else if (iPlayer == 3)
        //{
        //    Score_P4 = Score_P4 + 500;
        //}
    }
}
