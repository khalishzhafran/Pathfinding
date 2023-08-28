using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private Transform[] targetPoints;

    private int currentPointIndex = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            GoToNextPoint();
        }
    }

    private void GoToNextPoint()
    {
        if (targetPoints.Length == 0)
        {
            return;
        }

        agent.SetDestination(targetPoints[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % targetPoints.Length;
    }
}
