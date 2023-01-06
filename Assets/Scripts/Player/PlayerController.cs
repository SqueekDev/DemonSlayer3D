using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Menu _menu;

    private readonly string _horizontalFloatName = "horizontal";
    private readonly string _verticalFloatName = "vertical";
    private float _horizontalInputValue;
    private float _verticalInputValue;
    private float _horizontal;
    private Vector3 _moveDirection;
    private Animator _animator;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_menu.IsPaused == false)
        {
            _horizontalInputValue = Input.GetAxis("Horizontal");
            _verticalInputValue = Input.GetAxis("Vertical");
            _animator.SetFloat(_horizontalFloatName, _horizontalInputValue);
            _animator.SetFloat(_verticalFloatName, _verticalInputValue);
            _horizontal = Input.GetAxis("Mouse X") * _rotateSpeed;
            transform.Rotate(0, _horizontal, 0);
        }
    }

    private void FixedUpdate()
    {
        _moveDirection = (transform.forward * _verticalInputValue + transform.right * _horizontalInputValue) * _moveSpeed;
        _controller.Move(_moveDirection * Time.fixedDeltaTime);
    }
}
