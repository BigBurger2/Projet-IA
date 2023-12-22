using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBoom : ActionNode
{
    
    private ICanTriBoomAtk e;
    public override void OnInit()
    {
        e = context.GetComponent<Entity>() as ICanTriBoomAtk;
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
            e.DoTriBoomAtk();
            return State.Success;
        }
        return State.Failure;
    }
}
