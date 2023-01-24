using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarInTransition : EnemyTransition
{
    [SerializeField] private Boss _stats;
    [SerializeField] private RoarState _state;

    private void Update()
    {
        if (_stats.HalfHPReached && _state.CastCount > 0)
            NeedTransit = true;
    }
}
