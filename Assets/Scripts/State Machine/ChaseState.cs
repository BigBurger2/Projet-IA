using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;

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
        if(isInAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
