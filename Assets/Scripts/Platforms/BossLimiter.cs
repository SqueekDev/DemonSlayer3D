using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLimiter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Collider _collider;


    private void OnEnable()
    {
        _spawner.BossDefeated += OnBossDefeated;
    }

    private void OnBossDefeated()
    {
        _collider.isTrigger = true;
        _spawner.BossDefeated -= OnBossDefeated;
    }
}
