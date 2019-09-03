using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTouch : TouchCollectable {

	public int points = 100;

	protected override void OnTouched(Player player)
	{
		player.points += points;
		base.OnTouched(player);
	}
}
