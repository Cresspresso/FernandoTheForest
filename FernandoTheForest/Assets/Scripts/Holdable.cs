using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour {

	public Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
	public Player playerHoldingSelf;
	public bool isBeingHeld { get { return playerHoldingSelf != null; } }
	
	public virtual void OnHeldBy(Player player)
	{
		playerHoldingSelf = player;
	}

	public virtual void OnDropped()
	{
		playerHoldingSelf = null;
	}

	public void MakePlayerDrop()
	{
		if (playerHoldingSelf != null)
		{
			playerHoldingSelf.Drop();
		}
		playerHoldingSelf = null;
	}

	protected virtual void OnDestroy()
	{
		MakePlayerDrop();
	}
}
