using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Collectable {

	public float points = 1000;

    public AudioClip A_Trophy;
    AudioSource S_Trophy;

    private void Start()
    {
        S_Trophy = GetComponent<AudioSource>();
    }

    public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);

        S_Trophy.PlayOneShot(A_Trophy, 1.0f);
		player.points += points;
	}
}
