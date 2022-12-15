using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody _rigidbody;
    private float _horizontalInputValue;
    private float _verticalInputValue;
    private float _angle;
    private Camera _mainCamera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _horizontalInputValue = Input.GetAxis("Horizontal");
        _verticalInputValue = Input.GetAxis("Vertical");
        Vector3 direction = Input.mousePosition - _mainCamera.WorldToScreenPoint(transform.position);
        _angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_horizontalInputValue * _moveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y, _verticalInputValue * _moveSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.up);
    }
}
