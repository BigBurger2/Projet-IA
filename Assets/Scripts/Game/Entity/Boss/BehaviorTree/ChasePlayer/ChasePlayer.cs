using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer: ActionNode
{
    private ICanChasePlayer e;
    [SerializeField] private float distanceWanted; 
    public override void OnInit()
    {
        e= context.GetComponent<Entity>() as ICanChasePlayer;
    }
    
    protected override void OnStart()
    {
        state = State.Running;
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (e != null)
        {
            if (e.DoChasePlayer(distanceWanted))
            {
                state = State.Success;
            }
        }
        else
        {
            state = State.Failure;
        }
        return state;
    }
}
