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
        
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (e != null)
        {
            if (e.DoWaitFoPlayer())
            {
                child.Update();
                return State.Success;
            }
            return State.Running;
        }
        return State.Failure;
    }
}
