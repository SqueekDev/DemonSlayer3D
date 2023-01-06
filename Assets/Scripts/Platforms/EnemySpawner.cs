using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _templates;
    [SerializeField] private PlatformTrigger _trigger;
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private int _count;
    [SerializeField] private int _spawnSpread;

    private Player _player;
    private WorldBuilder _worldBuilder;

    public event UnityAction BossDefeated;

    private void Awake()
    {
        _worldBuilder = GetComponentInParent<WorldBuilder>();
    }

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
            int spread = Random.Range(-_spawnSpread, _spawnSpread);
            Vector3 spawnPosition = new Vector3(transform.position.x + spread, transform.position.y, transform.position.z + spread);
            Enemy template = _templates[Random.Range(0, _templates.Count)];
            Enemy enemy = Instantiate(template, spawnPosition, Quaternion.identity);
            enemy.Init(_player, _worldBuilder);
            enemy.Dying += OnEnemyDied;

            if (enemy.TryGetComponent(out Boss boss))
            {
                boss.Defeated += OnBossDefeated;
            }

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
        _player.AddHealth(enemy.MaxHealth);
    }

    private void OnBossDefeated(Boss boss)
    {
        boss.Defeated -= OnBossDefeated;
        BossDefeated?.Invoke();
    }
}
