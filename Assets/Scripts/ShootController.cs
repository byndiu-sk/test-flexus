using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab; // ������ �������
    [SerializeField]
    private Transform _muzzle; // ������� ��� ������ �������
    [SerializeField]
    private float _bulletSpeed = 10.0f; // �������� �������

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
            // ���������� ��������� ������� (��������, �������� ����)
            bulletController.FireBullet(_bulletSpeed, _muzzle.forward);

        }
    }
}
