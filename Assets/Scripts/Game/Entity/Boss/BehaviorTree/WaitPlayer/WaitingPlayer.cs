using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WaitingPlayer : DecoratorNode
{

    private ICanWaitPlayer e;
    public override void OnInit()
    {
        e = context.GetComponent<Entity>() as ICanWaitPlayer;
    }
    
    private Collider2D collider;
    protected override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnStop()
    {
        throw new System.NotImplementedException();
    }

    protected override State OnUpdate()
    {
        if (e != null)
        {
            if (e.DoWaitFoPlayer())
            {
                return State.Success;
            }
            return State.Running;
        }
        return State.Failure;
    }
}
