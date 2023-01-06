using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _shieldSlider;
    [SerializeField] private Boss _boss;

    private void OnEnable()
    {
        _boss.HealthChanged += OnHealthChanged;
        _boss.ShieldValueChanged += OnShieldValueChanged;
        _hpSlider.value = 1;
        _shieldSlider.value = 0;
    }

    private void OnDisable()
    {
        _boss.HealthChanged -= OnHealthChanged;
        _boss.ShieldValueChanged -= OnShieldValueChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _hpSlider.value = (float)currentHealth / maxHealth;
    }

    private void OnShieldValueChanged(int currentCapacity, int maxCapacity)
    {
        _shieldSlider.value = (float)currentCapacity / maxCapacity;
    }
}
