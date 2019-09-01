using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {

	public float speedBonusTime = 10;
	public ParticleSystem pickupEffects;

	private void Start()
	{
		pickupEffects.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
		pickupEffects.gameObject.SetActive(false);
	}

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		player.GiveSpeedBoost(speedBonusTime);
		pickupEffects.transform.SetParent(transform.parent);
		pickupEffects.gameObject.SetActive(true);
	}
}
