using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveState : EnemyState
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _agent.enabled = true;
    }

    private void OnDisable()
    {
        _agent.enabled = false;
    }

    private void Update()
    {
        _agent.SetDestination(Target.transform.position);
    }
}
