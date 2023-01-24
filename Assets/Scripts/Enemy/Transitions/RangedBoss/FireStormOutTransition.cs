using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStormOutTransition : EnemyTransition
{
    [SerializeField] private FireStormState _state;
    [SerializeField] private AudioSource _audio;

    private void OnDisable()
    {
        _audio.Stop();
    }

    private void Update()
    {
        if (_state.FireBallsAmount <= 0)
            NeedTransit = true;
    }
}
