using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Collectable {

	public float points = 1000;
    public AudioSource S_Trophy;

    public override void OnHeldBy(Player player)
	{
        S_Trophy.Play(0);
        player.points += points;
        S_Trophy.transform.SetParent(null);

        base.OnHeldBy(player);
	}
}
