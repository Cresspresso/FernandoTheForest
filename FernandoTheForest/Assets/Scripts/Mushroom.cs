using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {

	public float speedBonusTime = 10;

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		player.speedBonusTimer = speedBonusTime; // reset timer for seconds
	}
}
