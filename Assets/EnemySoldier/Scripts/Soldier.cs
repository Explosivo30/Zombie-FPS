using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform route;
    
    enum State
    {
        Idle,
        Chase,
        Shooting,
        Patrolling,
        Dead,
    };
    State state = State.Idle;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.Idle:            UpdateIdle();               break;

            case State.Chase:

                break;

            case State.Patrolling:

                break;


        }

        if(target)
        {
            navMeshAgent.SetDestination(target.position);
        }
        
    }

    private void UpdateIdle()
    {
        
    }
}
