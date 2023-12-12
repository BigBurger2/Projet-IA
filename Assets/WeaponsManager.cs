using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    private Rigidbody2D[] allWeaponsRB;
    private int nbChild;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        allWeaponsRB = GetComponentsInChildren<Rigidbody2D>();
        nbChild = allWeaponsRB.Length;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
