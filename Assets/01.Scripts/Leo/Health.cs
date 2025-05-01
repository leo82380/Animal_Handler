using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action OnDie;
    public event Action<int> OnHealthChange;
    
    [SerializeField] private int _maxHealth;
    
    [SerializeField]private int _currentHealth;

    private void Awake()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChange?.Invoke(_currentHealth);
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        OnDie?.Invoke();
    }

    public void RestoreHealth(int health)
    {
        _currentHealth += health;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        OnHealthChange?.Invoke(_currentHealth);
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }
}