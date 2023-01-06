using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Menu _menu;

    private Vector3 _offset;
    private float _angleY;

    private void Awake()
    {
        _offset = _target.position - transform.position;
    }

    private void OnEnable()
    {
        _menu.GamePaused += OnGamePauded;
    }

    private void OnDisable()
    {
        _menu.GamePaused -= OnGamePauded;        
    }

    private void Start()
    {
        transform.position = _target.position - _offset;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        _angleY = _target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, _angleY, 0);
        transform.position = _target.position - (rotation * _offset);
        transform.LookAt(_target);
    }

    private void OnGamePauded(bool isPaused)
    {
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
