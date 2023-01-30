using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Enemy))]
public class AttackState : EnemyState
{
    [SerializeField] private List<ParticleSystem> _effects;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _attackSounds;

    private float _angle;

    protected readonly string AttackTriggerName = "Attack";
    protected Coroutine AttackCorutine;
    protected Animator Animator;
    protected Enemy Stats { get; private set; }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Stats = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        Attack(Target);

        for (int i = 0; i < _effects.Count; i++)
        {
            _effects[i].Play();
        }
    }

    private void OnDisable()
    {
        StopAttack(Target);

        for (int i = 0; i < _effects.Count; i++)
        {
            _effects[i].Stop();
        }
    }

    private void Update()
    {
        RotateToPlayer();
    }

    protected virtual void Attack(Player target)
    {
        CheckCorutine(AttackCorutine);
        AttackCorutine = StartCoroutine(MeleeAttack(target));
    }

    protected void StopAttack(Player target)
    {
        CheckCorutine(AttackCorutine);
    }

    protected void PlayAttackSound()
    {
        AudioClip attackSound = _attackSounds[Random.Range(0, _attackSounds.Count)];
        _audioSource.PlayOneShot(attackSound);
    }

    private void RotateToPlayer()
    {
        Vector3 direction = Target.transform.position - transform.position;
        _angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
    }

    private IEnumerator MeleeAttack(Player target)
    {
        float delayTime = Stats.CurrentAttackDelay;
        WaitForSeconds delay = new WaitForSeconds(delayTime);

        while (enabled)
        {
            Animator.SetTrigger(AttackTriggerName);
            PlayAttackSound();
            target.ApplyDamage(Stats.CurrentDamage);
            yield return delay;
        }
    }
}
