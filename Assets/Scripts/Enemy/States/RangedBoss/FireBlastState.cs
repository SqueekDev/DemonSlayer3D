using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlastState : RangedAttackState
{
    [SerializeField] private int _fireBallsAmount;

    private readonly string _triggerName = "FireBlast";

    public int FireBallsAmount => _fireBallsAmount;

    protected override void Attack(Player target)
    {
        CheckCorutine(AttackCorutine);

        AttackCorutine = StartCoroutine(FireBlast(target));
    }

    private IEnumerator FireBlast(Player target)
    {
        float fireBallSpawnDelayTime = 0.01f;
        WaitForSeconds fireBallSpawnDelay = new WaitForSeconds(fireBallSpawnDelayTime);
        float skillCastDelayTime = 1f;
        WaitForSeconds skillCastDelay = new WaitForSeconds(skillCastDelayTime);

        while (_fireBallsAmount > 0)
        {
            Animator.SetTrigger(_triggerName);
            yield return skillCastDelay;
            int fireBallsInSpell = 20;

            if (fireBallsInSpell < _fireBallsAmount)
            {
                for (int i = 0; i < fireBallsInSpell; i++)
                {
                    int spreadValue = 10;
                    int spread = Random.Range(-spreadValue, spreadValue);
                    Vector3 targetSpreadPosition = new Vector3(target.transform.position.x + spread, target.transform.position.y, target.transform.position.z + spread);
                    LaunchFireBall(targetSpreadPosition);
                    _fireBallsAmount--;
                    yield return fireBallSpawnDelay;
                }
            }
            else
            {
                _fireBallsAmount = 0;
            }
        }
    }
}
