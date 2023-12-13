using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public WeaponsManager WM;
    public CustomInput input;

    private Rigidbody2D[] allWeaponsRb;

    private int nbChild;
    private int index;

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
}
