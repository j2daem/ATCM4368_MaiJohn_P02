using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Variables
    [Header("Settings")]
    [SerializeField] int _maxHealth = 5;

    private int _currentHealth;

    #region Getters
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    #endregion

    #region Events
    public event System.Action HealthUpdated;
    public event System.Action Killed;
    #endregion

    #endregion

    private void Awake()
    {
        _currentHealth = 0;
    }

    public void IncreaseHealth(int healAmount)
    {
        _currentHealth += healAmount;
        HealthUpdated?.Invoke();
    }

    public void DecreaseHealth(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Kill();
        }

        HealthUpdated?.Invoke();
    }

    private void Kill()
    {
        Killed?.Invoke();
    }
}
