using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private List<EnemySpawner> _spawnPoints;

    public Transform StartPoint => _startPoint;
    public Transform EndPoint => _endPoint;
    public List<EnemySpawner> SpawnPoints => _spawnPoints;
}
