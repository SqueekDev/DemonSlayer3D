using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWall : MonoBehaviour
{
    [SerializeField] private PlatformTrigger _trigger;

    private void OnEnable()
    {
        _trigger.Activated += OnTriggerActivated;
    }

    private void OnTriggerActivated()
    {
        _trigger.Activated -= OnTriggerActivated;
        Destroy(gameObject);
    }
}
