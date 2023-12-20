using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
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

    public override void OnDeath()
    {
        Debug.Log("Swtich vers l'ecran de \" Holy shit i'm dead \"");
    }
}
