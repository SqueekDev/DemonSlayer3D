using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startHealth;

    private int _maxHealth;
    private int _currentHealth;

    public int Money { get; private set; }

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int, int> HealthChanged;

    public void ApplyDamage(int damage)
    {
        Debug.Log($"Take {damage} damage");
    }
}
