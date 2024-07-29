using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private PlayerAnimations _playerAnimations;
    private PlayerActions _actions;
    private Rigidbody2D _rb2D;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _actions = new PlayerActions();
        _rb2D = GetComponent<Rigidbody2D>();
        _playerAnimations = GetComponent<PlayerAnimations>();
        
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
        if (_moveDirection == Vector2.zero)
        {
            _playerAnimations.SetMoveBoolTransition(false);
            return;
        }
        
        _playerAnimations.SetMoveBoolTransition(true);
        _playerAnimations.SetMoveAnimation(_moveDirection);
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
