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
    private bool _killed = false;

    #region Getters
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    public bool IsKilled => _killed;
    #endregion

    #region Events
    public event System.Action HealthIncreased;
    public event System.Action HealthDecreased;
    public event System.Action HealthUpdated;
    public event System.Action Killed;
    #endregion

    #endregion

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _killed = false;
    }

    public void IncreaseHealth(int healAmount)
    {
        _currentHealth += healAmount;
        HealthIncreased?.Invoke();
        HealthUpdated?.Invoke();
    }

    public void UpdateHealth(int damageAmount)
    {
        int previousHealth = _currentHealth;

        _currentHealth -= damageAmount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Kill();
        }

        else if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        if (previousHealth < _currentHealth)
        {
            HealthIncreased?.Invoke();
        }

        else if (previousHealth > _currentHealth)
        {
            HealthDecreased?.Invoke();
        }
        
        HealthUpdated?.Invoke();
    }

    private void Kill()
    {
        _killed = true;
        Killed?.Invoke();
    }
}
