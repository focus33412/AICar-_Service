using UnityEngine;

public class MouseDragCamera : MonoBehaviour
{
    public float minYPosition = 1f;          // ����������� ���������� ������� ������ �� ��� Y
    public float maxYPosition = 10f;         // ������������ ���������� ������� ������ �� ��� Y
    public float movementSensitivity = 0.1f; // ���������������� ����������� ������

    private Vector3 dragOrigin;        // ��������� ������� ���� ��� ������ ��������������
    private Vector3 originalPosition;  // �������� ������� ������ ��� ������ ��������������

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���������� ��������� ������� ���� � ������� ������ ��� ������� ����� ������ ����
            dragOrigin = Input.mousePosition;
            originalPosition = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            // ��������� ������ ����������� � ��������� ������ (X, Y)
            Vector3 offset = (Input.mousePosition - dragOrigin) * movementSensitivity;

            // ����������� ������ ����������� �� ��������� ������ � ������� ������������ (X, Z)
            Vector3 move = new Vector3(-offset.x, 0, -offset.y);

            // ��������� ������ ����������� � ������� ������
            Vector3 newPosition = originalPosition + move;
            newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, maxYPosition); // ������������ ��������� �� ��� Y
            transform.position = newPosition;
        }
    }
}
