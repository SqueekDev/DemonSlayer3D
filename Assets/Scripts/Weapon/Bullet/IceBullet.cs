using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullet
{
    [SerializeField] private int _freezingModifier;
    [SerializeField] private int _startFreezingTime;

    private int _freezingTime;

    private void Start()
    {
        _freezingTime = _startFreezingTime + Player.IceBulletModifier;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.TryGetComponent(out IDamageable damageable))
            damageable.Freeze(_freezingTime, _freezingModifier);
    }
}
