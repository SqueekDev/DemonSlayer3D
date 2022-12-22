using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardenedBulletUpgrade : Upgrade
{
    protected override void UpgadeAbility(int value, int cost)
    {
        Player.UpgradeHardenedBullet(value, cost);
    }
}
