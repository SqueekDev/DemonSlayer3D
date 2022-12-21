using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AttackState : EnemyState
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private float _angle;

    protected Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
        RotateToPlayer();
    }

    protected virtual void Attack(Player target)
    {
        Animator.Play("Attack");
        target.ApplyDamage(_damage);
    }

    private void RotateToPlayer()
    {
        Vector3 direction = Target.transform.position - transform.position;
        _angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
    }
}
