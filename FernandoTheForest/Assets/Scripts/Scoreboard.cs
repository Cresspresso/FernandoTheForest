using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour {

	public Text[] pointsTexts = new Text[4];
	public RectTransform[] panels = new RectTransform[4];

	private struct Pair
	{
		public float points;
		public int index;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("MenuScene");
	}

	private void Start()
	{
		var scores = PersistentScores.instance.scores;
		for (int i = 0; i < 4; i++)
		{
			pointsTexts[i].text = string.Format("{0}", scores[i]);
		}

		var wow = new Pair[4];
		for (int i = 0; i <4; i++)
		{
			wow[i].index = i;
			wow[i].points = scores[i];
		}

		var ordered = wow.OrderBy(x => x.points).ToArray();
		for (int oi = 0; oi < 4; oi++)
		{
			var p = ordered[oi];
			panels[p.index].SetAsFirstSibling();
		}
	}
}
