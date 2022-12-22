using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletUpgrade : Upgrade
{
    protected override void UpgadeAbility(int value, int cost)
    {
        Player.UpgradeIceBullet(value, cost);
    }
}
