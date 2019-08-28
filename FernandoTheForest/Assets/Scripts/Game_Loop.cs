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
    public float iTime = 0;

    public Text TimeText;

    // Use this for initialization
    void Start () {
        iTime = 240;
	}
	
	// Update is called once per frame
	void Update () {
        iTime = iTime - Time.deltaTime;
        float fTime = iTime / 100;
        string sTime = string.Format("{0:N2}", fTime);
        TimeText.text = sTime;
	}

    void TimetoPoints ()
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

    void Collectable ()
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

    void Trophy () {
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
