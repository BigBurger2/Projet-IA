using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class StateManager : MonoBehaviour
{
    public State currentState;
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        //State nextState = currentState?.Do();
        State nextState = currentState?.RunCurrentState();

        if (nextState != null) //currentState)
        {
            //Switch to the next state
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        //currentState.OnStop();
        currentState = nextState;
        //nextState.OnStart();
    }   
}
