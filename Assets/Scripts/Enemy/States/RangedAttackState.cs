using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : AttackState
{
    [SerializeField] private FireBall _fireBall;
    [SerializeField] private RangeAttackPoint _attackPoint;
    [SerializeField] private float _ballSpeed;

    protected override void Attack(Player target)
    {
        Animator.Play("Attack");
        FireBall currentFireBall = Instantiate(_fireBall, _attackPoint.transform.position, Quaternion.identity);
        Vector3 direction = target.transform.position - _attackPoint.transform.position;
        currentFireBall.Rigidbody.AddForce(direction.normalized * _ballSpeed, ForceMode.Impulse);
    }
}
