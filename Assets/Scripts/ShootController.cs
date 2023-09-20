using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _bulletPrefabs; // ������ �������
    [SerializeField]
    private Transform _muzzle; // ������� ��� ������ �������
    [SerializeField]
    private float _bulletSpeed = 10.0f; // �������� �������

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
            // ���������� ��������� ������� (��������, �������� ����)
            bulletController.FireBullet(_bulletSpeed, _muzzle.forward);

        }

    }
}
