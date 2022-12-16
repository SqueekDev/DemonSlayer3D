using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshRebake : MonoBehaviour
{
    [SerializeField] private WorldBuilder _worldBuilder;

    private NavMeshSurface _surface;   

    private void Awake()
    {
        _surface = GetComponent<NavMeshSurface>();
    }

    private void OnEnable()
    {
        _worldBuilder.PlatformCreated += OnPlatformCreated;
    }

    private void OnDisable()
    {
        _worldBuilder.PlatformCreated -= OnPlatformCreated;
    }

    private void OnPlatformCreated()
    {
        _surface.BuildNavMesh();
    }
}
