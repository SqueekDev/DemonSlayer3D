using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlastInTransition : EnemyTransition
{
    [SerializeField] private Boss _stats;
    [SerializeField] private FireBlastState _blastState;
    [SerializeField] private FireStormState _stormState;

    private void Update()
    {
        if (_stats.QuarterHPReached && _blastState.FireBallsAmount > 0 && _stormState.FireBallsAmount <= 0)
            NeedTransit = true;
    }
}
