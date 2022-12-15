using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _templates;
    [SerializeField] private SpawnTrigger _trigger;
    [SerializeField] private Player _player;
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private int _count;

    private void OnEnable()
    {
        _trigger.Activated += OnTriggerActivated;
    }

    private void OnDisable()
    {
        _trigger.Activated -= OnTriggerActivated;
    }

    private IEnumerator InstantiateEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayBetweenSpawn);

        for (int i = 0; i < _count; i++)
        {
            Enemy template = _templates[Random.Range(0, _templates.Count)];
            Enemy enemy = Instantiate(template, transform.position, Quaternion.identity);
            enemy.Init(_player);
            yield return delay;
        }
    }

    private void OnTriggerActivated()
    {
        StartCoroutine(InstantiateEnemies());
    }
}
