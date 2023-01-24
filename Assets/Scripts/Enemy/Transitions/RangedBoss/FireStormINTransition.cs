using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStormINTransition : EnemyTransition
{
    [SerializeField] private Boss _stats;
    [SerializeField] private FireStormState _state;

    private void Update()
    {
        if (_stats.HalfHPReached && _state.FireBallsAmount > 0)
            NeedTransit = true;
    }
}
