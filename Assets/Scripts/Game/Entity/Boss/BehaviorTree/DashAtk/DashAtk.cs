using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAtk: ActionNode
{
    
    private iCanDashAtk e;
    public override void OnInit()
    {
        e = context.GetComponent<Entity>() as iCanDashAtk;
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
            e.DoDashAtk();
            return State.Success;
        }
        return State.Failure;
    }
}
