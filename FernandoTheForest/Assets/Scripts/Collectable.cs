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

    public Game_Loop m_Game_Loop;
    public GameObject Trophy;

	public override void OnHeldBy(Player player)
	{
		base.OnHeldBy(player);
		player.Drop();
	}

	public override void OnDropped()
	{
		playerHoldingSelf.points += points;

        m_Game_Loop = GameObject.FindObjectOfType(typeof(Game_Loop)) as Game_Loop;
        if (Trophy.name == "Trophy")
        {
            m_Game_Loop.Trophy();
            m_Game_Loop.ScoreBoard();
        }
        else
        { m_Game_Loop.Collectable(); }

		base.OnDropped();
		Destroy(gameObject);
	}
}
