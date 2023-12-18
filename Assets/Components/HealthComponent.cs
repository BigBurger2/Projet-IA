using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float health;

    public void ChangeValue(float diff)
    {
        health += diff;
    }

    public bool IsBellowZero()
    {
        return health < 0;
    }
}
