using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : AttackState
{
    [SerializeField] private float _ballSpeed;
    [SerializeField] private FireBall _fireBall;
    [SerializeField] private RangeAttackPoint _attackPoint;

    protected float BallSpeed => _ballSpeed;
    protected FireBall FireBall => _fireBall;
    protected RangeAttackPoint AttackPoint => _attackPoint;

    protected override void Attack(Player target)
    {
        CheckCorutine(AttackCorutine);
        AttackCorutine = StartCoroutine(RangedAttack(target));
    }

    protected void LaunchFireBall(Vector3 target)
    {
        FireBall currentFireBall = Instantiate(_fireBall, _attackPoint.transform.position, Quaternion.identity, transform);
        Vector3 direction = target - _attackPoint.transform.position;
        currentFireBall.Rigidbody.AddForce(direction.normalized * _ballSpeed, ForceMode.Impulse);
    }

    private IEnumerator RangedAttack(Player target)
    {
        float delayTime = Stats.CurrentAttackDelay;
        WaitForSeconds castDelay = new WaitForSeconds(delayTime); 

        while (enabled)
        {
            Animator.SetTrigger(AttackTriggerName);
            PlayAttackSound();
            LaunchFireBall(target.transform.position);
            yield return castDelay;
        }
    }
}
