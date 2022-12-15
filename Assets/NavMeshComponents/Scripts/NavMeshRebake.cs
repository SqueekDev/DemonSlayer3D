using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshRebake : MonoBehaviour
{
    private void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
