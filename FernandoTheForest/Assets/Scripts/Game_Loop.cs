using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Game_Loop : MonoBehaviour {
    
    public int iPlayer = 0;
    public int TimeBonus = 0;
    public float iTime = 1;

    public Text TimeText;
    public Text[] ScoreLabels = new Text[4];

    private PlayerSpawner m_Players;
    public AudioSource S_Music;

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
            TimeText.text = string.Format("{0}:{1}", 0, 0);
        }

        for (int i = 0; i < 4; i++)
        {
            ScoreLabels[i].text = string.Format("{0}", m_Players.playerInstances[i].spawnedPlayer.points);
        }

        if (iTime <= 0)
        {
			var pers = PersistentScores.instance;
			var inst = m_Players.playerInstances;
			var sel = inst.Select(x => x.spawnedPlayer.points);
			pers.scores = sel.ToArray();
			if (pers.scores.Length != 4) { Debug.LogError("invalid scores size"); }
			SceneManager.LoadScene("HighScore");
        }

		if (Input.GetKey(KeyCode.Comma))
		{
			iTime -= Time.deltaTime * 100;
		}

        //S_Music.Play(0);
        //S_Music.transform.SetParent(null);
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

    public void cHourglass(int iGlass)
    {
        iTime = iTime + iGlass;
    }
}
