using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfLowHP : DecoratorNode
{
    
    private ICanLowHp e;
    public override void OnInit()
    {
        e = context.GetComponent<Entity>() as ICanLowHp;
    }
    
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (e !=  null)
        {
            if (e.IsLowHp())
            {
                return State.Success;
            }
        }
        return State.Failure;
    }
}
