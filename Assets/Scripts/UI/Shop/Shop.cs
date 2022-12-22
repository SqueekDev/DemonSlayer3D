using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private List<Upgrade> _upgrades;
    [SerializeField] private List<BuyBullet> _buyBullets;
    [SerializeField] private List<ShootingMode> _shootingModes;

    private void OnEnable()
    {
        _player.UpgradePointsChanged += OnUpgradePointsChanged;
        OnUpgradePointsChanged(_player.UpgradePoints);
    }

    private void OnDisable()
    {
        _player.UpgradePointsChanged -= OnUpgradePointsChanged;
    }

    private void OnUpgradePointsChanged(int points)
    {
        for (int i = 0; i < _upgrades.Count; i++)
        {
            if (points >= _upgrades[i].Cost)
            {
                _upgrades[i].ActivateButton();
            }
            else
            {
                _upgrades[i].DeactivateButton();
            }
        }

        for (int i = 0; i < _buyBullets.Count; i++)
        {
            if (points >= _buyBullets[i].Cost)
            {
                _buyBullets[i].ActivateButton();
            }
            else
            {
                _buyBullets[i].DeactivateButton();
            }
        }

        for (int i = 0; i < _shootingModes.Count; i++)
        {
            if (points >= _shootingModes[i].Cost)
            {
                _shootingModes[i].ActivateButton();
            }
            else
            {
                _shootingModes[i].DeactivateButton();
            }
        }
    }
}
