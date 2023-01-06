using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(Enemy))]
public class AttackState : EnemyState
{
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
    }

    private void OnDisable()
    {
        StopAttack(Target);
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
            Animator.SetTrigger("Attack");
            target.ApplyDamage(Stats.CurrentDamage);
            yield return delay;
        }
    }
}
