using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyBullet : ButtonActivator
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Player _player;

    public event UnityAction<Bullet> BulletBuyed;

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
        _upgradeButton.gameObject.SetActive(true);
        Button.gameObject.SetActive(false);
        _player.ReducePoints(Cost);
        BulletBuyed?.Invoke(_bullet);
    }
}
