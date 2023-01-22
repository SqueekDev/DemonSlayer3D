using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private float _minTimeDelay;
    [SerializeField] private float _maxTimeDelay;

    private void OnEnable()
    {
        StartCoroutine(BurstCorutine());
    }

    private void OnDisable()
    {
        StopCoroutine(BurstCorutine());        
    }

    private IEnumerator BurstCorutine()
    {
        while (enabled)
        {
            float delay = Random.Range(_minTimeDelay, _maxTimeDelay);
            yield return new WaitForSeconds(delay);
            _explosionEffect.Play();
        }
    }
}
