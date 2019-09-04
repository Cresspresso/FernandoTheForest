using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShroom : TouchCollectable {

	public float slowTime = 5;

	protected override void OnTouched(Player player)
	{
		player.GiveSlowEffect(slowTime);
		base.OnTouched(player);
	}
}
