using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyBullet : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Player _player;

    public int Cost => _cost;

    public event UnityAction<Bullet> BulletBuyed;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnClick);
    }

    public void ActivateButton()
    {
        _buyButton.interactable = true;
    }

    public void DeactivateButton()
    {
        _buyButton.interactable = false;
    }

    private void OnClick()
    {
        _upgradeButton.gameObject.SetActive(true);
        _buyButton.gameObject.SetActive(false);
        _player.ReducePoints(Cost);
        BulletBuyed?.Invoke(_bullet);
    }
}
