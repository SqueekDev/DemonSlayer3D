using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boss))]
public class FireStormState : RangedAttackState
{
    [SerializeField] private int _fireBallsAmount;

    private readonly string _triggerName = "FireStorm";

    public int FireBallsAmount => _fireBallsAmount;

    protected override void Attack(Player target)
    {
        CheckCorutine(AttackCorutine);

        AttackCorutine = StartCoroutine(FireStorm(target));
    }

    private IEnumerator FireStorm(Player target)
    {
        float delayTime = 0.1f;
        WaitForSeconds delay = new WaitForSeconds(delayTime);
        Animator.SetTrigger(_triggerName);
        float animationDelay = 0.5f;
        yield return new WaitForSeconds(animationDelay);

        while (_fireBallsAmount > 0)
        {
            int spreadValue = 5;
            int spread = Random.Range(-spreadValue, spreadValue);
            Vector3 targetSpreadPosition = new Vector3(target.transform.position.x + spread, target.transform.position.y, target.transform.position.z + spread);
            LaunchFireBall(targetSpreadPosition);
            _fireBallsAmount--;
            yield return delay;
        }
    }
}
