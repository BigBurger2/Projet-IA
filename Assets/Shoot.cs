using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Weapons;
    public Transform Target;

    private Rigidbody2D[] allWeaponsRb;
    private int nbChild;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        nbChild = allWeaponsRb.Length;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Action()
    {
        Weapons.transform.GetChild(index).gameObject.SetActive(true);


    }
}
