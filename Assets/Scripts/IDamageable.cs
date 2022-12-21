using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void ApplyDamage(int damage);

    public void Burn(int damage, float burningTime);

    public void Freeze(float freezingTime, float freezingModifier);
}
