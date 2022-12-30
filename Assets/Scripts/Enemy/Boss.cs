using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : Enemy
{
    [SerializeField] private int _boostModifier;

    protected bool HalfHpReached = false;
    protected bool QuarterHpReached = false;
    protected int BoostModifier => _boostModifier;

    public event UnityAction<Boss> Defeated;

    private void OnEnable()
    {
        Dying += OnDying;
    }

    private void OnDisable()
    {
        Dying -= OnDying;
    }

    public override void ApplyDamage(int damage)
    {
        int halfHpDivider = 2;
        int quarterHpDivider = 4;

        if (CurrentHealth <= MaxHealth / halfHpDivider && HalfHpReached == false)
        {
            UpgradeStats();
            HalfHpReached = true;
        }

        if (CurrentHealth <= MaxHealth / quarterHpDivider && QuarterHpReached == false)
        {
            UpgradeStats();
            QuarterHpReached = true;
        }

        base.ApplyDamage(damage);
    }

    protected virtual void UpgradeStats()
    {
        CurrentDamage *= BoostModifier;
        CurrentSpeed += BoostModifier;
    }

    private void OnDying(Enemy enemy)
    {
        Defeated?.Invoke(this);
    }
}
