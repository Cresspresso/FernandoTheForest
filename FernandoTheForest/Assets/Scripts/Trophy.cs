using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Collectable {

	public float points = 1000;

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);

		player.points += points;
	}
}
