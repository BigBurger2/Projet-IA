using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BigZoneAtk : ActionNode
{
    private ICanBigZoneAtk e;
    
    public override void OnInit()
    {
        e = context.GetComponent<Entity>() as ICanBigZoneAtk;
        
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
            e.DoBigZoneAttack();
            return State.Success;
        }
        return State.Failure;
    }
}
