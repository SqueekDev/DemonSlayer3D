using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTransition : MonoBehaviour
{
    [SerializeField] private EnemyState _targetState;

    protected Player Tagret { get; private set; }

    public EnemyState TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Tagret = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
