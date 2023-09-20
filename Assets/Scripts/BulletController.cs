using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explodeParticle;

    private float _initialSpeed = 10.0f; // ��������� �������� �������
    private float _gravity = 9.81f; // ����������� ������� ������

    private Vector3 _initialPosition; // ��������� ������� �������
    private Vector3 _initialVelocity; // ��������� �������� �������
    private float _startTime; // ��� �������
    private bool _isFired = false; // ���������, �� �����, �� ������ ��� ���������
    private bool _isBounced = false;

    public LayerMask collisionMask;
    public Transform blade;
    private float speed = 15;
    private float rotSpeed = 800;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Explode();
            return;
        }

        if (!_isBounced)
        {
            Vector3 reflectDirection = Vector3.Reflect(_initialVelocity.normalized, other.transform.forward.normalized);

            // ������ �������� ���� ������� ���� ��������
            _initialPosition = transform.position;
            _initialVelocity = reflectDirection * _initialSpeed * 0.9f;

            _startTime = Time.time;
            _isBounced = true;
        }
        else
        {
            Explode();
        }
    }

    private void Explode()
    {
        _isFired = false;
        _explodeParticle.gameObject.transform.parent = null;
        _explodeParticle.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    // ����� ��� ����������� ������� ����� �������
    public void FireBullet(float initialSpeed, Vector3 direction)
    {
        _initialSpeed = initialSpeed;
        _initialVelocity = direction.normalized * initialSpeed;
        _startTime = Time.time; // �������� ��� �������
        _isFired = true;
    }

   
    public void ResetBullet()
    {
        transform.position = _initialPosition;
        _isFired = false;
    }
}
