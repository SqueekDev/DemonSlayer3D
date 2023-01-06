using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlastOutTransition : EnemyTransition
{
    [SerializeField] private FireBlastState _state;

    private void Update()
    {
        if (_state.FireBallsAmount <= 0)
        {
            NeedTransit = true;
        }
    }
}
