using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(Enemy))]
public class AttackState : EnemyState
{
    private float _lastAttackTime;
    private float _angle;
    private Enemy _stats;

    protected Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        _stats = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _stats.CurrentAttackDelay;
        }

        _lastAttackTime -= Time.deltaTime;
        RotateToPlayer();
    }

    protected virtual void Attack(Player target)
    {
        Animator.Play("Attack");
        target.ApplyDamage(_stats.CurrentDamage);
    }

    private void RotateToPlayer()
    {
        Vector3 direction = Target.transform.position - transform.position;
        _angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
    }
}
