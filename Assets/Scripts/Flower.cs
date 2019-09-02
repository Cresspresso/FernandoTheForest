using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Collectable {

	public float wallHacksTime = 10;

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		player.wallHacksTimer = wallHacksTime;
	}
}
