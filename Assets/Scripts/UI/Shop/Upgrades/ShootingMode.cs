using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShootingMode : ButtonActivator
{
    [SerializeField] private Player _player;
    [SerializeField] private List<ShootPoint> _shootPoints;

    public event UnityAction<List<ShootPoint>> ShootingModeUpgraded;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);   
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);        
    }

    private void OnClick()
    {
        Button.gameObject.SetActive(false);
        _player.ReducePoints(Cost);
        ShootingModeUpgraded?.Invoke(_shootPoints);
    }
}
