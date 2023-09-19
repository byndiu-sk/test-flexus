using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _initialSpeed = 10.0f; // ��������� �������� �������
    private float _gravity = 9.81f; // ����������� ������� ������

    private Vector3 _initialPosition; // ��������� ������� �������
    private Vector3 _initialVelocity; // ��������� �������� �������
    private float _startTime; // ��� �������
    private bool _isFired = false; // ���������, �� �����, �� ������ ��� ���������

    private void Start()
    {
        // �������� ��������� ������� �������
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_isFired)
        {
            // ��� �������
            float time = Time.time - _startTime;
            float horizontalSpeed = _initialVelocity.x;
            float verticalSpeed = _initialVelocity.y - _gravity * time;
            float forwardSpeed = _initialVelocity.z; // �������� ������ �� �� Z
            Vector3 newPosition = _initialPosition + new Vector3(
                horizontalSpeed * time,
                verticalSpeed * time - 0.5f * _gravity * Mathf.Pow(time, 2),
                forwardSpeed * time
            );
            transform.position = newPosition;
        }
    }

    // ����� ��� ����������� ������� ����� �������
    public void FireBullet(float initialSpeed, Vector3 direction)
    {
        _initialSpeed = initialSpeed;
        _initialVelocity = direction.normalized * initialSpeed;
        _startTime = Time.time; // �������� ��� �������
        _isFired = true;
    }

    // ����� ��� ���������� ������� � ��������� ������� (�������� ��� ����������������)
    public void ResetBullet()
    {
        transform.position = _initialPosition;
        _isFired = false;
    }
}
