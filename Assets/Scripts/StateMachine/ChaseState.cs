using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class ChaseState : State
{
    public IdleState idleState;
    public AttackState attackState;
    public bool isInAttackRange;
    public float followDistance = 10f;
    public float followSpeed;

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
        idleState.distancePlayer = Math.Sqrt(Math.Pow(idleState.player.transform.position.x - transform.position.x, 2) + Math.Pow(idleState.player.transform.position.y - transform.position.y, 2));
        FollowPlayer();
        if(isInAttackRange)
        {
            return attackState;
        }
        if (!idleState.canSeeThePlayer)
        {
            return idleState;
        }
        else
        {
            return this;
        }
    }

    void FollowPlayer()
    {
        idleState.distance = Vector2.Distance(transform.position, idleState.rbP.position);

        idleState.agent.SetDestination(idleState.rbP.position);
        idleState.agent.speed = followSpeed;

        /*destination = player.transform.position - transform.position;
        rb.velocity = destination.normalized * followSpeed;*/
        //else destination = pattern[nextPoint] - transform.position;
        if(idleState.distancePlayer > followDistance)
        {
            idleState.canSeeThePlayer = false;
        }
    }
}
