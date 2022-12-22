using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletUpgrade : Upgrade
{
    protected override void UpgadeAbility(int value, int cost)
    {
        Player.UpgradeFireBullet(value, cost);
    }
}
