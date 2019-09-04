using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour {

	public Text[] pointsTexts = new Text[4];
    public GameObject[] notSafeIndicators = new GameObject[4];
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
		var stats = PersistentScores.instance.stats;
		for (int i = 0; i < 4; i++)
		{
            var stat = stats[i];
			pointsTexts[i].text = string.Format("{0}", stat.points);
            notSafeIndicators[i].SetActive(!stat.wasSafe);
		}

		var wow = new Pair[4];
		for (int i = 0; i <4; i++)
		{
			wow[i].index = i;
			wow[i].points = stats[i].points;
		}

		var ordered = wow.OrderBy(x => x.points).ToArray();
		for (int i = 0; i < 4; i++)
		{
			var p = ordered[i];
			panels[p.index].SetAsFirstSibling();
		}
	}
}
