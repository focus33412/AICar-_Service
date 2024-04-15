using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        Linear,
        Loop
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int movingTo = 0;
    public Transform[] PathElements;
    public MovementPath NextPath; // ��������� ����
    public GameObject car;
    private int k = 0;
    public void OnDrawGizmos()
    {
        if (PathElements == null || PathElements.Length < 2)
            return;

        for (int i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }

        if (PathType == PathTypes.Loop)
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
            yield break;

        while (true)
        {
            yield return PathElements[movingTo];

            if (movingTo >= PathElements.Length - 1)
            {
                // ������� �� ��������� ����, ���� ������� ��������
                if (NextPath != null)
                {
                    movingTo = 0; // ��������� �� ������ ������ ����
                    yield return null; // ��� ����� ����� ������, ���� ���������
                    NextPath.StartNextPath(); // ������ ���������� ����
                    yield break;
                }
                else
                {
                    yield break; // ���������� �����������, ���� ��� ���������� ����
                }
            }

            movingTo += movementDirection;
        }
    }
    public void krra()
    {
        k++;
    }
    private void Update()
    {
        if (k > 0)
        {
            car.transform.Translate(transform.up*1);
        car.transform.Rotate(0, 50, 0);
        }
        
    }
    // ������ ���������� ����
    public void StartNextPath()
    {
        if (NextPath != null && NextPath.PathElements.Length > 0)
        {
            // ��������� ������� �� ������ ���������� ����
            transform.position = NextPath.PathElements[0].position;
            movingTo = 0;
        }
    }
}