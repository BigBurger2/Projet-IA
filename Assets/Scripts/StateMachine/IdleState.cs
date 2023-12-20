using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public bool canSeeThePlayer;
    public ChaseState chaseState;

    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStop()
    {
        throw new System.NotImplementedException();
    }

    public override State Do()
    {
        if(canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
