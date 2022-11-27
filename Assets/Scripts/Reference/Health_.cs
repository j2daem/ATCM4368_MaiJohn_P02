using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_ : MonoBehaviour, IDamageable
{
    [Header("Settings")]
    [SerializeField] int _maxHealth = 3;
    [SerializeField] bool _damageable = true;
    public int MaxHealth=>_maxHealth;

    private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    [Header("References")]
    [SerializeField] AudioClip _damagedSFX;
    [SerializeField] ParticleSystem _deathVFX = null;
    [SerializeField] AudioClip _deathSFX = null;

    public event Action HealthUpdated;
    public event Action Killed;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    #region Modify Current Health
    public void IncreaseHealth(int healAmount)
    {
        _currentHealth += healAmount;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        Debug.Log("Healed " + this.gameObject.name + " for " + healAmount + ". Current health: " + _currentHealth);

        //Update health bar event
        HealthUpdated?.Invoke();
    }

    public void DecreaseHealth(int damageAmount)
    {
        if (_damageable)
        {
            _currentHealth -= damageAmount;

            Debug.Log("Hurt " + this.gameObject.name + " for " + damageAmount + ". Current health: " + _currentHealth);

            if (_damagedSFX != null)
            {
                AudioHelper.PlayClip2D(_damagedSFX, 1f);
            }

            if (_currentHealth <= 0)
            {
                Kill();
            }

            //Update health bar event
            HealthUpdated?.Invoke();
        }
    }
    #endregion

    public void Kill()
    {
        Debug.Log(this.gameObject.name + " has died...");

        if (_deathVFX != null)
        {
            Instantiate(_deathVFX, transform.position, Quaternion.identity);
        }

        if (_deathSFX != null)
        {
            AudioHelper.PlayClip2D(_deathSFX, 1f);
        }

        Killed?.Invoke();

        Destroy(this.gameObject);
    }

    public void EnableDamageable()
    {
        _damageable = true;
    }

    public void DisableDamageable()
    {
        _damageable = false;
    }
}
