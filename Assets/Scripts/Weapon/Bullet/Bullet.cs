using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private ParticleSystem _hitEnemyEffect;
    [SerializeField] private AudioSource _enemyHitSound;
    [SerializeField] private AudioSource _stoneHitSound;

    protected Player Player;
    protected ParticleSystem HitEnemyEffect => _hitEnemyEffect;
    protected AudioSource EnemyHitSound => _enemyHitSound;
    protected AudioSource StoneHitSound => _stoneHitSound;

    public Sprite Icon => _icon;
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
            HitEnemy(_hitEnemyEffect, _enemyHitSound);
        }
        else if (other.gameObject.TryGetComponent(out Stone stone))
        {
            HitEnemy(_hitEnemyEffect, _stoneHitSound);
        }
        else if (other.gameObject.TryGetComponent(out BulletDestroyer destroyer))
        {
            Destroy(gameObject);
        }
    }

    protected void HitEnemy(ParticleSystem particleSystem, AudioSource audioSource)
    {
        StartCoroutine(HitEnemyCorutine(particleSystem, audioSource));
    }

    private IEnumerator HitEnemyCorutine(ParticleSystem particleSystem, AudioSource audioSource)
    {
        Rigidbody.velocity = new Vector3(0, 0, 0);
        audioSource.Play();
        particleSystem.Play();
        float delay = particleSystem.main.duration;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
