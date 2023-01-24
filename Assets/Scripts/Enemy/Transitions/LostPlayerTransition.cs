using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostPlayerTransition : EnemyTransition
{
    [SerializeField] private float _minLostDistance;

    private void Update()
    {
        if (Vector3.Distance(Tagret.transform.position, transform.position) > _minLostDistance)
            NeedTransit = true;
    }
}
