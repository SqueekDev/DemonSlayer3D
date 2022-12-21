using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    [SerializeField] private int _startArmor;

    private int _maxHealth;
    private int _currentHealth;
    private int _currentArmor;
    private int _maxArmor = 100;

    public int Money { get; private set; }

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction PlayerDied;

    private void Start()
    {
        _maxHealth = _startHealth;
        _currentHealth = _startHealth;
        _currentArmor = _startArmor;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage * (_maxArmor - _currentArmor) / _maxArmor;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            PlayerDied?.Invoke();
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void Upgdage()
    {

    }
}
