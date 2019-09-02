using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Collectable {

	public float points = 1000;

	public Game_Loop m_Game_Loop;
	public GameObject trophy;

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);

		player.points += points;

		m_Game_Loop = GameObject.FindObjectOfType(typeof(Game_Loop)) as Game_Loop;
		if (trophy.name == "Trophy")
		{
			m_Game_Loop.Trophy();
			m_Game_Loop.ScoreBoard();
		}
		else
		{ m_Game_Loop.Collectable(); }
	}
}
