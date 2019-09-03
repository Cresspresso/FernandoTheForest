using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Collectable {

	public float points = 1000;

	private Game_Loop m_Game_Loop;

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);

		player.points += points;
	}
}
