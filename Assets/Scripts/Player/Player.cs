using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    [SerializeField] private int _startArmor;
    [SerializeField] private int _startLifesteal;
    [SerializeField] private int _startDamage;
    [SerializeField] private PlayerStats _shop;

    private int _currentHealth;
    private int _experience = 0;
    private int _maxArmor = 100;

    public int UpgradePoints { get; private set; }
    public int MaxHealth { get; private set; }
    public int CurrentArmor { get; private set; }
    public int CurrentLifesteal { get; private set; }
    public int Damage { get; private set; }
    public int FireBulletModifier { get; private set; }
    public int IceBulletModifier { get; private set; }
    public int HardenedBulletModifier { get; private set; }

    public event UnityAction PlayerDied;
    public event UnityAction BulletChanged;
    public event UnityAction<int> ArmorChanged;
    public event UnityAction<int> DamageChanged;
    public event UnityAction<int> LifestealChanged;
    public event UnityAction<int> UpgradePointsChanged;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        MaxHealth = _startHealth;
        _currentHealth = _startHealth;
        CurrentArmor = _startArmor;
        CurrentLifesteal = _startLifesteal;
        Damage = _startDamage;
        HealthChanged?.Invoke(_currentHealth, MaxHealth);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage * (_maxArmor - CurrentArmor) / _maxArmor;
        HealthChanged?.Invoke(_currentHealth, MaxHealth);

        if (_currentHealth <= 0)
        {
            PlayerDied?.Invoke();
        }
    }

    public void AddExpirience(int points)
    {
        int experienceForLvlUp = 100;
        _experience += points;

        if (_experience >= experienceForLvlUp)
        {
            _experience -= experienceForLvlUp;
            UpgradePoints++;
            UpgradePointsChanged?.Invoke(UpgradePoints);
        }
    }

    public void UpgradeHealth(int value, int cost)
    {
        MaxHealth += value;
        HealthChanged?.Invoke(_currentHealth, MaxHealth);
        ReducePoints(cost);
    }

    public void UpgradeArmor(int value, int cost)
    {
        CurrentArmor += value;
        ArmorChanged?.Invoke(CurrentArmor);
        ReducePoints(cost);
    }

    public void UpgradeLifesteal(int value, int cost)
    {
        CurrentLifesteal += value;
        LifestealChanged?.Invoke(CurrentArmor);
        ReducePoints(cost);
    }

    public void UpgradeDamage(int value, int cost)
    {
        Damage += value;
        DamageChanged?.Invoke(Damage);
        ReducePoints(cost);
    }

    public void UpgradeFireBullet(int value, int cost)
    {
        FireBulletModifier += value;
        ReducePoints(cost);
    }

    public void UpgradeIceBullet(int value, int cost)
    {
        FireBulletModifier += value;
        ReducePoints(cost);
    }

    public void UpgradeHardenedBullet(int value, int cost)
    {
        FireBulletModifier += value;
        ReducePoints(cost);
    }

    public void ChangeBulletButtonClick()
    {
        BulletChanged?.Invoke();
    }

    public void ReducePoints(int reduceNumber)
    {
        UpgradePoints -= reduceNumber;
        UpgradePointsChanged?.Invoke(UpgradePoints);
    }
}
