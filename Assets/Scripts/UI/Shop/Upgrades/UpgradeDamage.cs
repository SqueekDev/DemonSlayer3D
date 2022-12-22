using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : Upgrade
{
    protected override void UpgadeAbility(int value, int cost)
    {
        Player.UpgradeDamage(value, cost);
    }
}
