using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState _firstState;

    private Player _target;
    private EnemyState _currentState;

    public EnemyState CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(EnemyState startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(EnemyState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
