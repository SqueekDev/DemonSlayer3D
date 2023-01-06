using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Enemy))]
public class RoarState : EnemyState
{
    [SerializeField] private int _castCount;
    [SerializeField] private int _damageDistance;

    private readonly string _triggerName = "Roar";
    private Animator _animator;
    private Enemy _stats;
    private Coroutine _roarCorutine;

    public int CastCount => _castCount;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stats = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        CheckCorutine(_roarCorutine);

        _roarCorutine = StartCoroutine(CastCoturine(Target));
    }

    private void OnDisable()
    {
        CheckCorutine(_roarCorutine);
    }

    private IEnumerator CastCoturine(Player target)
    {
        float castDelayTime = 2f;
        WaitForSeconds castDelay = new WaitForSeconds(castDelayTime);

        while (_castCount > 0)
        {
            _animator.SetTrigger(_triggerName);
            yield return castDelay;

            if (Vector3.Distance(transform.position, target.transform.position) < _damageDistance)
            {
                target.ApplyDamage(_stats.CurrentDamage);
            }

            _castCount--;
        }
    }
}
