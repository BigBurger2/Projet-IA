using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public IdleState idleState;
    public ChaseState chaseState;
    //public override void OnStart()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void OnStop()
    //{
    //    throw new System.NotImplementedException();
    //}

    public override State RunCurrentState()  //Do()
    {
        Debug.Log("I Have Attacked !");
        if (!idleState.canSeeThePlayer)
        {
            return idleState;
        }
        if (!chaseState.isInAttackRange)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
