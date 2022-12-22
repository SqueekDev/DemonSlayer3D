using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    protected Player Player;

    public int Damage { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Player = GetComponentInParent<Player>();
        Damage = Player.Damage;
        transform.parent = null;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(Damage);
            Destroy(gameObject);
        }

        if (other.gameObject.TryGetComponent(out BulletDestroyer destroyer))
        {
            Destroy(gameObject);
        }
    }
}
