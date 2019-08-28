using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Loop : MonoBehaviour {

    public int Score_P1 = 0;
    public int Score_P2 = 0;
    public int Score_P3 = 0;
    public int Score_P4 = 0;

    public int iPlayer = 0;
    public int TimeBonus = 0;
    public float iTime = 1;

    public Text TimeText;
    public Text P1Score;
    public Text P2Score;
    public Text P3Score;
    public Text P4Score;

    // Use this for initialization
    void Start () {
        iTime = 240;
        P1Score.text = " ";
        P2Score.text = " ";
        P3Score.text = " ";
        P4Score.text = " ";
	}
	
	// Update is called once per frame
	void Update () {
        iTime = iTime - Time.deltaTime;
        if (iTime > 0)
        {
            TimeText.text = string.Format("{0:N2}", iTime/100);
        }
        else
        {
            TimeText.text = "0";
        }

        P1Score.text = "Player 1: " + string.Format("{0}", Score_P1);
        P2Score.text = "Player 2: " + string.Format("{0}", Score_P2);
        P3Score.text = "Player 3: " + string.Format("{0}", Score_P3);
        P4Score.text = "Player 4: " + string.Format("{0}", Score_P4);
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

    public void TimetoPoints ()
    {
        if (iTime >= 180)
        {
            TimeBonus = 500;
        }
        else if (iTime >= 150)
        {
            TimeBonus = 400;
        }
        else if (iTime >= 120)
        {
            TimeBonus = 300;
        }
        else if (iTime >= 60)
        {
            TimeBonus = 200;
        }
        else
        {
            TimeBonus = 100;
        }

        if (iPlayer == 0)
        {
            Score_P1 = Score_P1 + TimeBonus;
        }
        else if (iPlayer == 1)
        {
            Score_P2 = Score_P2 + TimeBonus;
        }
        else if (iPlayer == 2)
        {
            Score_P3 = Score_P3 + TimeBonus;
        }
        else if (iPlayer == 3)
        {
            Score_P4 = Score_P4 + TimeBonus;
        }
    }

    public void Collectable ()
    {
        if (iPlayer == 0)
        {
            Score_P1 = Score_P1 + 100;
        }
        else if (iPlayer == 1)
        {
            Score_P2 = Score_P2 + 100;
        }
        else if (iPlayer == 2)
        {
            Score_P3 = Score_P3 + 100;
        }
        else if (iPlayer == 3)
        {
            Score_P4 = Score_P4 + 100;
        }
    }

    public void Trophy () {
        if (iPlayer == 0)
        {
            Score_P1 = Score_P1 + 500;
        }
        else if (iPlayer == 1)
        {
            Score_P2 = Score_P2 + 500;
        }
        else if (iPlayer == 2)
        {
            Score_P3 = Score_P3 + 500;
        }
        else if (iPlayer == 3)
        {
            Score_P4 = Score_P4 + 500;
        }
    }
}
