using System.Collections.Generic;
using UnityEngine;

public class BreadcrumbFollower : MonoBehaviour
{
    [Header("Riferimenti")]
    [Tooltip("GameObject")]
    [SerializeField] private Transform targetToFollow;

    [Header("Movimento")]
    [Tooltip("Velocity")]
    [SerializeField] private float moveSpeed = 5f;

    [Tooltip("FollowPoint")]
    [SerializeField] private float minDistanceBetweenPoints = 0.2f;

    [Tooltip("DelayPoint")]
    [SerializeField] private int delaySteps = 8;

    private List<Vector3> positionHistory = new List<Vector3>();

    private void Update()
    {
        if (targetToFollow == null) return;

        RecordTargetPosition();
        MoveAlongHistory();
    }

    private void RecordTargetPosition()
    {
        if (positionHistory.Count == 0)
        {
            positionHistory.Add(targetToFollow.position);
            return;
        }

        Vector3 lastRecordedPosition = positionHistory[positionHistory.Count - 1];
        if (Vector3.Distance(targetToFollow.position, lastRecordedPosition) >= minDistanceBetweenPoints)
        {
            positionHistory.Add(targetToFollow.position);
        }
    }

    private void MoveAlongHistory()
    {
        if (positionHistory.Count > delaySteps)
        {
            Vector3 targetPoint = positionHistory[0];

            transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPoint) < 0.05f)
            {
                positionHistory.RemoveAt(0);
            }
        }
    }
}

