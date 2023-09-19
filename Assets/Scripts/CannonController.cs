using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 30.0f;
    [SerializeField]
    private GameObject _barrel;

    [Header("Barrel Rotation Limits")]
    [SerializeField]
    [Range(-90.0f, 90.0f)] // Додали атрибут Range для обмеження значень
    private float _minPitch = -90.0f; // Мінімальний кут повороту пушки
    [SerializeField]
    [Range(-90.0f, 90.0f)] // Додали атрибут Range для обмеження значень
    private float _maxPitch = 90.0f;  // Максимальний кут повороту пушки

    private Transform _carriageTransform;
    private Transform _barrelTransform;

    private float pitch = 0.0f;

    void Start()
    {
        // Отримуємо посилання на трансформ основи та пушки
        _carriageTransform = transform;
        _barrelTransform = _barrel.transform;
    }

    void Update()
    {
        // Отримуємо введення користувача для обертання основи гармати (по горизонталі)
        float horizontalInput = Input.GetAxis("Horizontal");
        float carriageRotation = horizontalInput * _rotationSpeed * Time.deltaTime;

        // Обертаємо основу гармати по горизонталі
        _carriageTransform.Rotate(Vector3.up, carriageRotation);

        // Отримуємо введення користувача для обертання пушки гармати (по вертикалі)
        float verticalInput = Input.GetAxis("Vertical");
        pitch += -verticalInput * _rotationSpeed * Time.deltaTime;

        // Обмежуємо кут обертання пушки з використанням _minPitch та _maxPitch
        pitch = Mathf.Clamp(pitch, _minPitch, _maxPitch);

        // Застосовуємо обертання пушки гармати по вертикалі
        _barrelTransform.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);
    }
}
