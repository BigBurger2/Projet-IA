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

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (e != null)
        {
            float distance = e.DoChasePlayer();
            if (distance <= distanceWanted)
            {
                state = State.Success;
            }
            state = State.Running;
        }
        else
        {
            state = State.Failure;
        }
        return state;
    }
}
