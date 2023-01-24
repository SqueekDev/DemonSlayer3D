using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FireBall : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private ParticleSystem _ballEffect;
    [SerializeField] private AudioSource _hitSound;

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
            StartCoroutine(ExplodeCorutine(player));
        else if (other.gameObject.TryGetComponent(out BulletDestroyer destroyer))
            Destroy(gameObject);
    }

    private IEnumerator ExplodeCorutine(Player player)
    {
        player.ApplyDamage(_stats.CurrentDamage);
        _explosionEffect.Play();
        _hitSound.Play();
        _ballEffect.Stop();
        Rigidbody.velocity = new Vector3(0, 0, 0);
        float delay = _explosionEffect.main.duration;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
