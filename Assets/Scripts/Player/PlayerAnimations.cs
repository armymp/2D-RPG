using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int _moveX = Animator.StringToHash("MoveX");
    private readonly int _moveY = Animator.StringToHash("MoveY");
    private readonly int _moving = Animator.StringToHash("IsMoving");
    private readonly int _dead = Animator.StringToHash("Dead");
    
    
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetDeadAnimation()
    {
        _animator.SetTrigger(_dead);
    }

    public void SetMoveBoolTransition(bool value)
    {
        _animator.SetBool(_moving, value);
    }

    public void SetMoveAnimation(Vector2 direction)
    {
        _animator.SetFloat(_moveX, direction.x);
        _animator.SetFloat(_moveY, direction.y);
    }
}
