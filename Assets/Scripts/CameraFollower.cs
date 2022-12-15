using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position - _player.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _player.position + _offset, _speed * Time.fixedDeltaTime);
    }
}
