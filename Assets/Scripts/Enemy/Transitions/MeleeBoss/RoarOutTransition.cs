using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarOutTransition : EnemyTransition
{
    [SerializeField] private RoarState _state;

    private void Update()
    {
        if (_state.CastCount <= 0)
            NeedTransit = true;
    }
}
