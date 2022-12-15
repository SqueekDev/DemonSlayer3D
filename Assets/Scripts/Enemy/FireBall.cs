using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FireBall : MonoBehaviour
{
    [SerializeField] private int _damage;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            Destroy(gameObject);
        }

        if (other.gameObject.TryGetComponent(out BulletDestroyer destroyer))
        {
            Destroy(gameObject);
        }
    }
}
