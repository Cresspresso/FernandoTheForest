using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTouch : TouchCollectable {

	public int points = 100;
	public ParticleSystem pickupEffects;
	public float rotateSpeed = 100;

	private void Start()
	{
		pickupEffects.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
		pickupEffects.gameObject.SetActive(false);
	}

	private void Update()
	{
		transform.Rotate(0, Time.deltaTime * rotateSpeed, 0, Space.Self);
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
