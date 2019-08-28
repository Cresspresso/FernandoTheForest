using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Holdable {
	
	public void OnCollisionEnter(Collision collision)
	{
		var door = collision.collider.GetComponentInParent<Door>();
		if (door != null)
		{
			door.Unlock();
			Destroy(gameObject);
		}
	}

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		rb.isKinematic = true;
	}

	public override void OnDropped()
	{
		rb.isKinematic = false;
		base.OnDropped();
	}

	private void FixedUpdate()
	{
		if (isBeingHeld)
		{
			rb.MovePosition(playerHoldingSelf.holdPos.position);
			rb.MoveRotation(playerHoldingSelf.holdPos.rotation);
		}
	}
}
