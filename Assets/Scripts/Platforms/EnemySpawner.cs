using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _templates;
    [SerializeField] private PlatformTrigger _trigger;
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private int _count;

    private Player _player;

    private void OnEnable()
    {
        _trigger.Activated += OnTriggerActivated;
    }

    public void InitPlayer(Player player)
    {
        _player = player;
    }

    private IEnumerator InstantiateEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayBetweenSpawn);

        for (int i = 0; i < _count; i++)
        {
            Enemy template = _templates[Random.Range(0, _templates.Count)];
            Enemy enemy = Instantiate(template, transform.position, Quaternion.identity);
            enemy.Init(_player);
            enemy.Dying += OnEnemyDied;
            yield return delay;
        }
    }

    private void OnTriggerActivated()
    {
        StartCoroutine(InstantiateEnemies());
        _trigger.Activated -= OnTriggerActivated;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDied;

        _player.AddExpirience(enemy.Reward);
    }
}
