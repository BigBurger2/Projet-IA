using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
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
        Debug.Log("I Have Attacked !");
        return this;
    }
}
