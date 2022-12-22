using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : Upgrade
{
    protected override void UpgadeAbility(int value, int cost)
    {
        Player.UpgradeHealth(value, cost);
    }
}
