using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : EnemyState
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _delay;

    private float _lastAttackTime;

    protected Animator Animator;

    protected void Start()
    {
        Animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    protected virtual void Attack(Player target)
    {
        Animator.Play("Attack");
        target.ApplyDamage(_damage);
    }
}
