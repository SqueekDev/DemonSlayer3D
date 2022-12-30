using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shootSpeed;
    [SerializeField] private Player _player;
    [SerializeField] private ShootPoint _startShootPoint;
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private List<BuyBullet> _buyBullets;
    [SerializeField] private List<ShootingMode> _shootingModes;

    private int _currentBulletNumber = 0;
    private Bullet _currentBullet;
    private List<ShootPoint> _shootPoints = new List<ShootPoint>();

    public event UnityAction<Bullet> BulletChanged;

    private void Awake()
    {
        _shootPoints.Add(_startShootPoint);
        ChangeBullet(_bullets[_currentBulletNumber]);
    }

    private void OnEnable()
    {
        _player.BulletChanged += OnBulletChange;

        for (int i = 0; i < _buyBullets.Count; i++)
        {
            _buyBullets[i].BulletBuyed += OnBulletBuyed;
        }

        for (int i = 0; i < _shootingModes.Count; i++)
        {
            _shootingModes[i].ShootingModeUpgraded += Add;
        }
    }

    private void OnDisable()
    {
        _player.BulletChanged -= OnBulletChange;

        for (int i = 0; i < _buyBullets.Count; i++)
        {
            _buyBullets[i].BulletBuyed -= OnBulletBuyed;
        }

        for (int i = 0; i < _shootingModes.Count; i++)
        {
            _shootingModes[i].ShootingModeUpgraded -= Add;
        }
    }

    private void Start()
    {
        StartCoroutine(ShootCorutine());
    }

    private IEnumerator ShootCorutine()
    {
        float delayStep = 0.2f;
        WaitForSeconds delay = new WaitForSeconds(delayStep);

        while (true)
        {
            Shoot();
            yield return delay;
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < _shootPoints.Count; i++)
        {
            Bullet currentBullet = Instantiate(_currentBullet, _shootPoints[i].transform.position, Quaternion.identity, transform);
            Vector3 direction = _shootPoints[i].TargetPoint.position - _shootPoints[i].transform.position;
            currentBullet.Rigidbody.AddForce(direction.normalized * _shootSpeed, ForceMode.Impulse);
        }        
    }

    private void Add(List<ShootPoint> shootPoints)
    {
        _shootPoints.AddRange(shootPoints);
    }

    private void OnBulletChange()
    {
        if (_currentBulletNumber == _bullets.Count - 1)
        {
            _currentBulletNumber = 0;
        }
        else
        {
            _currentBulletNumber++;
        }

        ChangeBullet(_bullets[_currentBulletNumber]);
    }

    private void ChangeBullet(Bullet bullet)
    {
        _currentBullet = bullet;
        BulletChanged?.Invoke(bullet);
    }

    private void OnBulletBuyed(Bullet bullet)
    {
        _bullets.Add(bullet);
    }
}
