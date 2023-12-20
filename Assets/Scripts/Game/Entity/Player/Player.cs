using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int point = 0;
    public int live = 3;
    public int lvl = 0;

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
            
        }
    }

    public override void OnDeath()
    {
        Debug.Log("Swtich vers l'ecran de \" Holy shit i'm dead \"");
    }
}
