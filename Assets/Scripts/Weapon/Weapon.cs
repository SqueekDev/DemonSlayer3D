using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _shootSpeed;

    private void Start()
    {
        StartCoroutine(ShootCorutine());
    }

    private IEnumerator ShootCorutine()
    {
        while (true)
        {
            float delay = 0.2f;
            Shoot();
            yield return new WaitForSeconds(delay);
        }
    }

    private void Shoot()
    {
        Bullet currentBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        Vector3 direction = _targetPoint.position - _shootPoint.position;
        currentBullet.Rigidbody.AddForce(direction.normalized * _shootSpeed, ForceMode.Impulse);
    }
}
