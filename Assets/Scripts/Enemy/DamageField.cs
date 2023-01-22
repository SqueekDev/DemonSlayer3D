using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageField : MonoBehaviour
{
    [SerializeField] private Vector3 _maxScale;
    [SerializeField] private float _timeToIncrease;

    private Enemy _stats;
    private float _currentTime = 0;

    private void Awake()
    {
        _stats = GetComponentInParent<Enemy>();
    }

    private void Update()
    {
        transform.DOScale(_maxScale, _timeToIncrease);
        _currentTime += Time.deltaTime;

        if (_currentTime > _timeToIncrease)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_stats.CurrentDamage);
        }
    }
}
