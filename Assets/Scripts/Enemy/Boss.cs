using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Boss : Enemy
{
    [SerializeField] private int _boostModifier;
    [SerializeField] private int _halfHPShieldCapacity;
    [SerializeField] private int _quarterHPShieldCapacity;

    private int _shieldCapacity;
    private bool _halfHPReached = false;
    private bool _quarterHPReached = false;

    public bool HalfHPReached => _halfHPReached;
    public bool QuarterHPReached => _quarterHPReached;
    public int MaxShieldCapacity { get; private set; }

    public event UnityAction<Boss> Defeated;
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> ShieldValueChanged;

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
        if (_shieldCapacity > 0)
        {
            _shieldCapacity--;
            ShieldValueChanged?.Invoke(_shieldCapacity, MaxShieldCapacity);
        }
        else
        {
            int halfHpDivider = 2;
            int quarterHpDivider = 4;

            if (CurrentHealth <= MaxHealth / halfHpDivider && _halfHPReached == false)
            {
                UpgradeStats();
                CurrentAttackDelay /= _boostModifier;
                _halfHPReached = true;
                _shieldCapacity = _halfHPShieldCapacity;
                MaxShieldCapacity = _halfHPShieldCapacity;
                ShieldValueChanged?.Invoke(_shieldCapacity, MaxShieldCapacity);
            }

            if (CurrentHealth <= MaxHealth / quarterHpDivider && _quarterHPReached == false)
            {
                UpgradeStats();
                _quarterHPReached = true;
                _shieldCapacity = _quarterHPShieldCapacity;
                MaxShieldCapacity = _quarterHPShieldCapacity;
                ShieldValueChanged?.Invoke(_shieldCapacity, MaxShieldCapacity);
            }

            base.ApplyDamage(damage);
            HealthChanged?.Invoke(CurrentHealth, MaxHealth);
        }
    }

    private void UpgradeStats()
    {
        CurrentDamage *= _boostModifier;
        CurrentSpeed += _boostModifier;
        ChangeSpeed();
    }

    private void OnDying(Enemy enemy)
    {
        Defeated?.Invoke(this);
    }
}
