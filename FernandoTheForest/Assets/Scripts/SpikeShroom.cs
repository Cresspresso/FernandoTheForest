using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShroom : Collectable {

	public float slowTime = 5;

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		player.GiveSlowEffect(slowTime);
	}
}
