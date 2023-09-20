using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _bulletPrefabs; // Префаб снаряду
    [SerializeField]
    private Transform _muzzle; // Позиція для викиду снаряду
    [SerializeField]
    private float _bulletSpeed = 10.0f; // Швидкість снаряду

    [SerializeField]
    private Slider _powerSlider;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        _bulletSpeed = _powerSlider.value * 100;
    }



    public void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefabs[Random.Range(0, _bulletPrefabs.Length)], _muzzle.position, _muzzle.rotation);

        BulletController bulletController = bullet.GetComponent<BulletController>();
        if (bulletController != null)
        {
            // Налаштуйте параметри снаряду (швидкість, напрямок тощо)
            bulletController.FireBullet(_bulletSpeed, _muzzle.forward);

        }

    }
}
