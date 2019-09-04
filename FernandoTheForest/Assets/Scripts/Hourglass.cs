using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : Collectable {

    public int iGlass = 20;

    public override void OnHeldBy(Player player)
    {
        base.OnHeldBy(player);

        var Game_Loop = FindObjectOfType<Game_Loop>();
        Game_Loop.cHourglass(iGlass);
    }
}
