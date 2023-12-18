using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class ICanTakeDamage : MonoBehaviour
{
    
    HealthComponent healthComponent;

    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
    }

    public void TakeDamage(float dmgAmount)
    {
        if (healthComponent != null)
        {
            healthComponent.ChangeValue(-dmgAmount);
        }
    }
}
