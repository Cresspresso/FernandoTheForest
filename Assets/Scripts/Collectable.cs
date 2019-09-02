using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Holdable
{
	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		player.Drop();
	}

	public override void OnDropped()
	{
		base.OnDropped();
		Destroy(gameObject);
	}
}
