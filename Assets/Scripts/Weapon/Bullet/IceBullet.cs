using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullet
{
    [SerializeField] private int _freezingModifier;
    [SerializeField] private float _startFreezingTime;

    private float _freezingTime;

    private void Start()
    {
        _freezingTime = _startFreezingTime;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.Freeze(_freezingTime, _freezingModifier);
        }
    }
}
