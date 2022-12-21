using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private float _startBurningTime;
    [SerializeField] private int _burningDamageModifier;

    private float _burningTime;

    private void Start()
    {
        _burningTime = _startBurningTime;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.Burn(Damage / _burningDamageModifier, _burningTime);
        }
    }
}
