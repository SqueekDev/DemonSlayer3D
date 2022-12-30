using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBoss : Boss
{
    protected override void UpgradeStats()
    {
        base.UpgradeStats();
        CurrentAttackDelay /= BoostModifier;
    }
}
