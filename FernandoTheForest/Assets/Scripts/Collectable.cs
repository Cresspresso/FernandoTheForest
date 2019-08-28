using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Holdable
{
	public float points = 1000;
	//public float rotateSpeed = 10;

	//private void FixedUpdate()
	//{
	//	rb.MoveRotation(Quaternion.Euler(0, rotateSpeed * Time.fixedDeltaTime, 0) * rb.rotation);
	//}

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		player.Drop();
	}

	public override void OnDropped()
	{
		playerHoldingSelf.points += points;
		base.OnDropped();
		Destroy(gameObject);
	}
}
