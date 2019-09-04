using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Collectable {

	public float wallHacksTime = 10;
    public AudioSource S_Flower;

    public override void OnHeldBy(Player player)
    {
        S_Flower.Play(0);
        S_Flower.transform.SetParent(null);

        base.OnHeldBy(player);
		player.wallHacksTimer = wallHacksTime;
	}
}
