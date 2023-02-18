using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCbehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform point;

    private void Start()
    {
        MoveNpc();
    }

    private void MoveNpc()
    {
        _agent.SetDestination(point.position);
    }
}
