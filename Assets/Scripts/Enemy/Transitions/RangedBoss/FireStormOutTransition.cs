using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStormOutTransition : EnemyTransition
{
    [SerializeField] private FireStormState _state;

    private void Update()
    {
        if (_state.FireBallsAmount <= 0)
        {
            NeedTransit = true;
        }
    }
}
