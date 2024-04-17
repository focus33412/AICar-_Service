using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{
    public Path pathToFollow; // ������ �� ��������� Path, �� �������� ����� ��������� ������
    public float movementSpeed = 5f; // �������� �������� ������� �� ����

    private int currentWaypointIndex = 0;
    private bool isMoving = true;

    private void Start()
    {
        if (pathToFollow != null && pathToFollow.waypoints.Count > 0)
        {
            transform.position = pathToFollow.waypoints[currentWaypointIndex].position;
        }
        else
        {
            Debug.LogWarning("Path to follow is not assigned or has no waypoints set.");
            enabled = false; // ��������� ������, ���� ���� �� ����� ��� �� ����� �����
        }
    }

    private void Update()
    {
        if (isMoving && pathToFollow != null && pathToFollow.waypoints.Count > 0)
        {
            MoveOnPath();
        }
    }

    private void MoveOnPath()
    {
        Vector3 targetPosition = pathToFollow.waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= pathToFollow.waypoints.Count)
            {
                if (pathToFollow.loop)
                {
                    currentWaypointIndex = 0;
                }
                else
                {
                    isMoving = false; // ������������� ��������, ���� ���� �� ��������
                }
            }
        }
    }

    // ����� ��� ��������� ������ ����
    public void SetPath(Path newPath)
    {
        pathToFollow = newPath;
        currentWaypointIndex = 0;
        isMoving = true;
    }
}
