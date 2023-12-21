using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Success, 
        Failure, 
        Running
    }
    [HideInInspector]
    public State state = State.Running;
    [HideInInspector]
    public bool started;
    [HideInInspector]
    public string guid;
    [HideInInspector]
    public Vector2 position; 
    [HideInInspector] 
    public GameObject context;

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

    public virtual Node Clone()
    {
        return Instantiate(this);
    }
    
    public virtual void OnInit() {
        // Nothing to do here
    }
    
    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
}
