using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Success, 
        Failure, 
        Running
    }

    public State state = State.Running;
    public bool started; 

    public State Update()
    {
        if (!started)
        {
            OnStart(); 
            started = true;
        }

        state = OnUpdate();

        if (state == State.Success || state == State.Failure) {
            OnStop();
            started = false;
        }

        return state;
    }

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
}
