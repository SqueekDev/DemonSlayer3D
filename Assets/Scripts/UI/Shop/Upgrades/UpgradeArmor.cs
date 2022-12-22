using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeArmor : Upgrade
{
    protected override void UpgadeAbility(int value, int cost)
    {
        Player.UpgradeArmor(value, cost);
    }
}
