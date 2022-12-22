using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardenedBullet : Bullet
{
    [SerializeField] private int _startPenetrationCount;

    private int _penetrationCount;

    private void Start()
    {
        _penetrationCount = _startPenetrationCount + Player.HardenedBulletModifier;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            if (_penetrationCount > 0)
            {
                damageable.ApplyDamage(Damage);
                _penetrationCount--;
            }
            else
            {
                damageable.ApplyDamage(Damage);
                Destroy(gameObject);
            }
        }

        if (other.gameObject.TryGetComponent(out BulletDestroyer destroyer))
        {
            Destroy(gameObject);
        }
    }
}
