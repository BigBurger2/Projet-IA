using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int point = 0;
    int live = 3;
    int lvl = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Heal()
    {
        live++;
    }

    void Damage()
    {
        live--;
        isDead();
    }

    void isDead()
    {
        if (live == 0)
        {
            //Game over
        }
    }

}
