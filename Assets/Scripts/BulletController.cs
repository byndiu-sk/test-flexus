using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _initialSpeed = 10.0f; // Початкова швидкість снаряду
    private float _gravity = 9.81f; // Прискорення вільного падіння

    private Vector3 _initialPosition; // Початкова позиція снаряду
    private Vector3 _initialVelocity; // Початкова швидкість снаряду
    private float _startTime; // Час пострілу
    private bool _isFired = false; // Прапорець, що вказує, чи снаряд вже вистрілено

    private void Start()
    {
        // Зберегти початкову позицію снаряду
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_isFired)
        {
            // Рух снаряду
            float time = Time.time - _startTime;
            float horizontalSpeed = _initialVelocity.x;
            float verticalSpeed = _initialVelocity.y - _gravity * time;
            float forwardSpeed = _initialVelocity.z; // Швидкість вперед по осі Z
            Vector3 newPosition = _initialPosition + new Vector3(
                horizontalSpeed * time,
                verticalSpeed * time - 0.5f * _gravity * Mathf.Pow(time, 2),
                forwardSpeed * time
            );
            transform.position = newPosition;
        }
    }

    // Метод для ініціалізації снаряду перед викидом
    public void FireBullet(float initialSpeed, Vector3 direction)
    {
        _initialSpeed = initialSpeed;
        _initialVelocity = direction.normalized * initialSpeed;
        _startTime = Time.time; // Зберігаємо час пострілу
        _isFired = true;
    }

    // Метод для повернення снаряду в початкову позицію (зазвичай для перезавантаження)
    public void ResetBullet()
    {
        transform.position = _initialPosition;
        _isFired = false;
    }
}
