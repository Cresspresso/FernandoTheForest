using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTouch : TouchCollectable {

	public int points = 100;
	public ParticleSystem pickupEffects;

	private void Start()
	{
		pickupEffects.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
		pickupEffects.gameObject.SetActive(false);
	}

	protected override void OnTouched(Player player)
	{
		try
		{
			player.points += points;
			pickupEffects.transform.SetParent(transform.parent);
			pickupEffects.gameObject.SetActive(true);
		}
		finally
		{
			base.OnTouched(player);
		}
	}
}
