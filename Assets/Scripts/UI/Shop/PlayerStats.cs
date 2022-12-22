using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _armor;
    [SerializeField] private TMP_Text _lifesteal;
    [SerializeField] private TMP_Text _upgradePoints;

    private void OnEnable()
    {
        _health.text = _player.MaxHealth.ToString();
        _upgradePoints.text = _player.UpgradePoints.ToString();
        _armor.text = _player.CurrentArmor.ToString();
        _lifesteal.text = _player.CurrentLifesteal.ToString();
        _damage.text = _player.Damage.ToString();
        _player.HealthChanged += OnHealthChanged;
        _player.UpgradePointsChanged += OnUpgradePointsChange;
        _player.ArmorChanged += OnArmorChanged;
        _player.LifestealChanged += OnLifestealChanged;
        _player.DamageChanged += OnDamageChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;        
        _player.UpgradePointsChanged -= OnUpgradePointsChange;
        _player.ArmorChanged -= OnArmorChanged;
        _player.LifestealChanged -= OnLifestealChanged;
        _player.DamageChanged -= OnDamageChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _health.text = maxHealth.ToString();
    }

    private void OnUpgradePointsChange(int points)
    {
        _upgradePoints.text = points.ToString();
    }

    private void OnArmorChanged(int armor)
    {
        _armor.text = armor.ToString();
    }

    private void OnDamageChanged(int damage)
    {
        _damage.text = damage.ToString();
    }

    private void OnLifestealChanged(int lifesteal)
    {
        _lifesteal.text = $"{lifesteal}%";
    }
}
