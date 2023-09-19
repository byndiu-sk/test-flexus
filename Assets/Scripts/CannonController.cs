using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 30.0f;
    [SerializeField]
    private GameObject _barrel;

    [Header("Barrel Rotation Limits")]
    [SerializeField]
    [Range(-90.0f, 90.0f)] // ������ ������� Range ��� ��������� �������
    private float _minPitch = -90.0f; // ̳�������� ��� �������� �����
    [SerializeField]
    [Range(-90.0f, 90.0f)] // ������ ������� Range ��� ��������� �������
    private float _maxPitch = 90.0f;  // ������������ ��� �������� �����

    private Transform _carriageTransform;
    private Transform _barrelTransform;

    private float pitch = 0.0f;

    void Start()
    {
        // �������� ��������� �� ��������� ������ �� �����
        _carriageTransform = transform;
        _barrelTransform = _barrel.transform;
    }

    void Update()
    {
        // �������� �������� ����������� ��� ��������� ������ ������� (�� ����������)
        float horizontalInput = Input.GetAxis("Horizontal");
        float carriageRotation = horizontalInput * _rotationSpeed * Time.deltaTime;

        // �������� ������ ������� �� ����������
        _carriageTransform.Rotate(Vector3.up, carriageRotation);

        // �������� �������� ����������� ��� ��������� ����� ������� (�� ��������)
        float verticalInput = Input.GetAxis("Vertical");
        pitch += -verticalInput * _rotationSpeed * Time.deltaTime;

        // �������� ��� ��������� ����� � ������������� _minPitch �� _maxPitch
        pitch = Mathf.Clamp(pitch, _minPitch, _maxPitch);

        // ����������� ��������� ����� ������� �� ��������
        _barrelTransform.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);
    }
}
