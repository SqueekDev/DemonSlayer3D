using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingStone : Stone
{
    [SerializeField] private float _minAnimationSpeed;
    [SerializeField] private float _maxAnimationSpeed;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        float animationSpeed = Random.Range(_minAnimationSpeed, _maxAnimationSpeed);
        _animator.speed *= animationSpeed;
    }
}
