
using UnityEngine;

public abstract class State : MonoBehaviour
{
    //public abstract void OnStart();
    //public abstract void OnStop();
    //public abstract State Do();
    public abstract State RunCurrentState();
}
