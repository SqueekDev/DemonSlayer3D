using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;

    public Transform TargetPoint => _targetPoint;
}
