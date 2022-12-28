using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private List<ButtonActivator> _buttons;

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
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (points >= _buttons[i].Cost)
            {
                _buttons[i].ActivateButton();
            }
            else
            {
                _buttons[i].DeactivateButton();
            }
        }
    }
}
