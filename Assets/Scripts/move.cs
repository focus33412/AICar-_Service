using UnityEngine;

public class MouseDragCamera : MonoBehaviour
{
    public float dragSpeed = 2f;
    public float minYPosition = 1f; // ����������� ������� �� ��� Y

    private Vector3 dragOrigin;
    private float startYPosition;

    void Start()
    {
        startYPosition = transform.position.y; // ���������� ��������� ������� ������ �� ��� Y
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);

        // ��������� ����������� ������
        transform.Translate(move, Space.World);

        // ������������ ������� ������ �� ��� Y
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, startYPosition, Mathf.Infinity);
        transform.position = clampedPosition;
    }
}
