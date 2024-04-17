using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>(); // ������ ����� ����
    public Color gizmosColor = Color.yellow; // ���� ��� ����������� ���� � ���������
    public bool loop = false; // ���� ������������ ����

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.2f);

            if (i < waypoints.Count - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
            else if (loop && waypoints.Count > 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[0].position);
            }
        }
    }
}
