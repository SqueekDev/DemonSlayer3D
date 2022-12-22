using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShootingMode : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private Button _button;
    [SerializeField] private Player _player;
    [SerializeField] private List<ShootPoint> _shootPoints;

    public int Cost => _cost;

    public event UnityAction<List<ShootPoint>> ShootingModeUpgraded;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);   
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);        
    }

    private void OnClick()
    {
        _button.gameObject.SetActive(false);
        _player.ReducePoints(Cost);
        ShootingModeUpgraded?.Invoke(_shootPoints);
    }

    public void ActivateButton()
    {
        _button.interactable = true;
    }

    public void DeactivateButton()
    {
        _button.interactable = false;
    }
}
