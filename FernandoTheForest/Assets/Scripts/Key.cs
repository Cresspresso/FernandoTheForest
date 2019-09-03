using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Key : Holdable {

	public int keyNumber = 1;

	public void OnCollisionEnter(Collision collision)
	{
		OnTriggerEnter(collision.collider);
	}

	private void OnTriggerEnter(Collider other)
	{
		var door = other.GetComponentInParent<Door>();
		if (door != null && door.keyNumberMask.Contains(keyNumber))
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
