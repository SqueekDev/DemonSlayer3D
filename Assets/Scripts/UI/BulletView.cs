using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Weapon _weapon;

    private void OnEnable()
    {
        _weapon.BulletChanged += OnBulletChange;
    }

    private void OnDisable()
    {
        _weapon.BulletChanged -= OnBulletChange;        
    }

    private void OnBulletChange(Bullet bullet)
    {
        _icon.sprite = bullet.Icon;
    }
}
