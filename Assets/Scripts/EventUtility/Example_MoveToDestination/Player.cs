using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        EventManager.AddListener<Vector3>(EventType.MoveToDestination, MoveToDestination);
    }

    public void MoveToDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<Vector3>(EventType.MoveToDestination, MoveToDestination);
    }
}
