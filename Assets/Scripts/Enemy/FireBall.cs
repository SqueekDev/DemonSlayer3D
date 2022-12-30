using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FireBall : MonoBehaviour
{
    private Enemy _stats;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _stats = GetComponentInParent<Enemy>();
        transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_stats.CurrentDamage);
            Destroy(gameObject);
        }

        if (other.gameObject.TryGetComponent(out BulletDestroyer destroyer))
        {
            Destroy(gameObject);
        }
    }
}
