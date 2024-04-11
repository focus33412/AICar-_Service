using UnityEngine;

public class MouseDragCamera : MonoBehaviour
{
    public float minYPosition = 1f;           // ����������� ���������� ������� ������ �� ��� Y
    public float maxYPosition = 10f;          // ������������ ���������� ������� ������ �� ��� Y
    public float movementSensitivity = 0.1f;  // ���������������� ����������� ������
    public float maxXMovement = 10f;          // ������������ ����������� ����������� ������ �� ��� X
    public float minXMovement = -10f;         // ����������� ����������� ����������� ������ �� ��� X
    public float maxZMovement = 10f;          // ������������ ����������� ����������� ������ �� ��� Z
    public float minZMovement = -10f;         // ����������� ����������� ����������� ������ �� ��� Z

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

            // ��������� ������������ �� ����������� �� ���� X � Z
            Vector3 newPosition = originalPosition + move;
            newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, maxYPosition); // ������������ ��������� �� ��� Y
            newPosition.x = Mathf.Clamp(newPosition.x, minXMovement, maxXMovement); // ������������ ����������� �� ��� X
            newPosition.z = Mathf.Clamp(newPosition.z, minZMovement, maxZMovement); // ������������ ����������� �� ��� Z

            // ��������� ����� ������� ������
            transform.position = newPosition;

            // ������� ���������� ������ � ������� ����� ������� �����������
            Debug.Log("Camera Position: " + transform.position);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // ������� ���������� ������ � ������� ����� ���������� ����
            Debug.Log("Final Camera Position: " + transform.position);
        }
    }
}
