using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private readonly int _moveX = Animator.StringToHash("MoveX");
    private readonly int _moveY = Animator.StringToHash("MoveY");
    private PlayerActions _actions;
    private Rigidbody2D _rb2D;
    private Animator _animator;
    private Vector2 _moveDirection;
    private void Awake()
    {
        _actions = new PlayerActions();
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadMovement();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Time.fixedDeltaTime to ignore framerate. Character moves in a fixed rate
        _rb2D.MovePosition(_rb2D.position + _moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void ReadMovement()
    {
        _moveDirection = _actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (_moveDirection == Vector2.zero) return;
        _animator.SetFloat(_moveX, _moveDirection.x);
        _animator.SetFloat(_moveY, _moveDirection.y);
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }
}
