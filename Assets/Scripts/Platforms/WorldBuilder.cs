using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Platform> _platformTemplates;
    [SerializeField] private Platform _startPlatform;

    private List<Platform> _spawnedPlatforms = new List<Platform>();

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
            SpawnPlatform();
        }

        int platformsLimit = 4;

        if (_spawnedPlatforms.Count >= platformsLimit)
        {
            RemovePlatform();
        }
    }

    private void SpawnPlatform()
    {
        Platform newPlatform = Instantiate(_platformTemplates[Random.Range(0, _platformTemplates.Count)]);
        newPlatform.transform.position = _spawnedPlatforms[_spawnedPlatforms.Count - 1].EndPoint.transform.position - newPlatform.StartPoint.localPosition;
        Init(newPlatform);
        _spawnedPlatforms.Add(newPlatform);
        PlatformCreated?.Invoke();
    }

    private void RemovePlatform()
    {
        Destroy(_spawnedPlatforms[0].gameObject);
        _spawnedPlatforms.RemoveAt(0);
    }

    private void Init(Platform platform)
    {
        for (int i = 0; i < platform.SpawnPoints.Count; i++)
        {
            platform.SpawnPoints[i].InitPlayer(_player);
        }
    }
}
