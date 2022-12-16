using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformTrigger : MonoBehaviour
{
    public UnityAction Activated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Activated?.Invoke();
            Destroy(gameObject);
        }
    }
}
