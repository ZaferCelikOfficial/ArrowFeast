using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentFollow : MonoBehaviour
{
    NavMeshAgent ArrowAgent;
    void Start()
    {
        ArrowAgent=this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ArrowAgent.SetDestination(ArrowPositionRead.ArrowPosition);
    }
}
