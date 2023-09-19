using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab; // Префаб снаряду
    [SerializeField]
    private Transform _muzzle; // Позиція для викиду снаряду
    [SerializeField]
    private float _bulletSpeed = 10.0f; // Швидкість снаряду

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        if (bulletController != null)
        {
            // Налаштуйте параметри снаряду (швидкість, напрямок тощо)
            bulletController.FireBullet(_bulletSpeed, _muzzle.forward);

        }
    }
}
