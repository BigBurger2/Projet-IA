using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public WeaponsManager WM;
    public CustomInput input;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        WM.Launch();
    }

    public void Stop()
    {
        WM.Stop();
    }
}
