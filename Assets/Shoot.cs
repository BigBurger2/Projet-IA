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
        nbChild = Weapons.transform.childCount;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Action()
    {
        Transform temp = Weapons.transform.GetChild(index);
        temp.GetComponent<WeaponMove>().Dir = (Target.position - transform.parent.position).normalized;
        temp.gameObject.SetActive(true);
        temp.GetComponent<WeaponMove>().fired = true;
        index++;
        index %= nbChild;
    }
}
