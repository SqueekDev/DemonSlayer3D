using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private ShootPoint _startShootPoint;

    private List<ShootPoint> _shootPoints = new List<ShootPoint>();

    private void Awake()
    {
        _shootPoints.Add(_startShootPoint);
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
            Bullet currentBullet = Instantiate(_bullet, _shootPoints[i].transform.position, Quaternion.identity);
            Vector3 direction = _shootPoints[i].TargetPoint.position - _shootPoints[i].transform.position;
            currentBullet.Rigidbody.AddForce(direction.normalized * _shootSpeed, ForceMode.Impulse);
        }        
    }

    private void Add(List<ShootPoint> shootPoints)
    {
        _shootPoints.AddRange(shootPoints);
    }
}
