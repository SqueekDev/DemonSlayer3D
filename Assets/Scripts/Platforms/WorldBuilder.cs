using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private int _bossPlatformNumber;
    [SerializeField] private int _statsModifier;
    [SerializeField] private Player _player;
    [SerializeField] private List<Platform> _platformTemplates;
    [SerializeField] private List<Platform> _bossPlatformTemplates;
    [SerializeField] private Platform _startPlatform;

    private int _currentPlatformNumber;
    private List<Platform> _spawnedPlatforms = new List<Platform>();

    public int StatsModifier => _statsModifier;

    public UnityAction PlatformCreated;

    private void Start()
    {
        _spawnedPlatforms.Add(_startPlatform);
        Init(_startPlatform);
        PlatformCreated?.Invoke();
    }

    private void Update()
    {
        if (_player.transform.position.z > _spawnedPlatforms[_spawnedPlatforms.Count - 1].transform.position.z)
        {
            _currentPlatformNumber++;

            if (_currentPlatformNumber < _bossPlatformNumber)
            {
                SpawnPlatform(_platformTemplates);
            }
            else
            {
                SpawnPlatform(_bossPlatformTemplates);
                _currentPlatformNumber = 0;
            }
        }

        int platformsLimit = 4;

        if (_spawnedPlatforms.Count >= platformsLimit)
        {
            RemovePlatform();
        }
    }

    private void SpawnPlatform(List<Platform> platforms)
    {
        Platform newPlatform = Instantiate(platforms[Random.Range(0, _platformTemplates.Count)], transform);
        newPlatform.transform.position = _spawnedPlatforms[_spawnedPlatforms.Count - 1].EndPoint.transform.position - newPlatform.StartPoint.localPosition;
        Init(newPlatform);
        _spawnedPlatforms.Add(newPlatform);
        PlatformCreated?.Invoke();
    }

    private void RemovePlatform()
    {
        for (int i = 0; i < _spawnedPlatforms[0].SpawnPoints.Count; i++)
        {
            _spawnedPlatforms[0].SpawnPoints[i].BossDefeated -= OnBossDefeated;
        }

        Destroy(_spawnedPlatforms[0].gameObject);
        _spawnedPlatforms.RemoveAt(0);
    }

    private void Init(Platform platform)
    {
        for (int i = 0; i < platform.SpawnPoints.Count; i++)
        {
            platform.SpawnPoints[i].InitPlayer(_player);
            platform.SpawnPoints[i].BossDefeated += OnBossDefeated;
        }
    }

    private void OnBossDefeated()
    {
        _statsModifier++;
    }
}
