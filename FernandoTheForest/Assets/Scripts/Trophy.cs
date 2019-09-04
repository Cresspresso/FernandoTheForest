using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : TouchCollectable {

	public float points = 500;
    public AudioSource S_Trophy;
    /*
    public override void OnHeldBy(Player player)
	{
        S_Trophy.Play(0);
        S_Trophy.transform.SetParent(null);
        player.points += points;

        base.OnHeldBy(player);
	}
    */
    protected override void OnTouched(Player player)
    {
        try
        {
            S_Trophy.Play(0);
            S_Trophy.transform.SetParent(null);

            player.points += points;
        }
        finally
        {
            base.OnTouched(player);
        }
    }
}
