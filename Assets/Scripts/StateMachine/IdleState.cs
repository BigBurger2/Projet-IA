using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.Rendering;


public class IdleState : State
{
    public float distance;
    [SerializeField] private Vector3[] pattern;
    [SerializeField] public GameObject player;
    private int nextPoint;
    public float speed;
    [SerializeField] public NavMeshAgent agent;
    public double distancePlayer;
    public bool canSeeThePlayer;
    public ChaseState chaseState;

    //public override void OnStart()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void OnStop()
    //{
    //    throw new System.NotImplementedException();
    //}

    public override State RunCurrentState() //Do()
    {
        distancePlayer = Math.Sqrt(Math.Pow(player.transform.position.x - transform.position.x, 2)+Math.Pow(player.transform.position.y - transform.position.y , 2));
        FollowPattern();
        if (canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    void FollowPattern()
    {
        distance = Vector2.Distance(transform.position, pattern[nextPoint]);
        /*destination = pattern[nextPoint] - transform.position;*/


        agent.SetDestination(pattern[nextPoint]);
        agent.speed = speed;

        if (distance < 2f)
        {
            nextPoint++;
            if (nextPoint == pattern.Length) nextPoint = 0;
        }
        if(distancePlayer < chaseState.followDistance)
        {
            canSeeThePlayer = true;
        }


    }
}
