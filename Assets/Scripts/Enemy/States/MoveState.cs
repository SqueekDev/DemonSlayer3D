using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class MoveState : EnemyState
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private readonly string _movingBooleanName = "IsMoving";

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _agent.enabled = true;
        _animator.SetBool(_movingBooleanName, true);
    }

    private void OnDisable()
    {
        _agent.enabled = false;
        _animator.SetBool(_movingBooleanName, false);
    }

    private void Update()
    {
        _agent.SetDestination(Target.transform.position);
    }
}
