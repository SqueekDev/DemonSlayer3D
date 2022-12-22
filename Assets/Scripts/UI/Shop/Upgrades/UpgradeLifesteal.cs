using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeLifesteal : Upgrade
{
    protected override void UpgadeAbility(int value, int cost)
    {
        Player.UpgradeLifesteal(value, cost);
    }
}
