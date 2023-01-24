using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private int _startBurningTime;
    [SerializeField] private int _burningDamageModifier;

    private int _burningTime;

    private void Start()
    {
        _burningTime = _startBurningTime * Player.FireBulletModifier;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.TryGetComponent(out IDamageable damageable))
            damageable.Burn(Damage / _burningDamageModifier, _burningTime);
    }
}
