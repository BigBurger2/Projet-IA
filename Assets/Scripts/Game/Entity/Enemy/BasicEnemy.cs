using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Entity
{
    public override void OnDeath()
    {
        // -1 oponent dans le game manager
        //animator death 
        //Drop Loot
        Debug.Log("DID YOU JUST KILL THIS WABBIT");
        CallEvent();
        Destroy(gameObject);
    }
}
