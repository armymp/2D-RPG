using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] 
    private PlayerStats stats;

    private PlayerAnimations _playerAnimations;

    private void Awake()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if (stats.Health <= 0f)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        _playerAnimations.SetDeadAnimation();
    }
}
