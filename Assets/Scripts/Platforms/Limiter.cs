using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private PlatformTrigger _trigger;

    private void Awake()
    {
        _collider.isTrigger = true;
    }

    private void OnEnable()
    {
        _trigger.Activated += OnTriggerActivated;
    }

    private void OnTriggerActivated()
    {
        _collider.isTrigger = false;
        _trigger.Activated -= OnTriggerActivated;
    }
}
