using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int point = 0;
    public int live = 3;
    public int lvl = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Heal()
    {
        live++;
    }

    public void Damage()
    {
        live--;
        isDead();
    }

    private void isDead()
    {
        if (live == 0)
        {
            
        }
    }

}
