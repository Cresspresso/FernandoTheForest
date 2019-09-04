using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : Collectable {

    public int iGlass = 20;
    public AudioSource S_Hourglass;

    public override void OnHeldBy(Player player)
    {
        S_Hourglass.Play(0);
        S_Hourglass.transform.SetParent(null);

        base.OnHeldBy(player);

        var Game_Loop = FindObjectOfType<Game_Loop>();
        Game_Loop.cHourglass(iGlass);
    }
}
