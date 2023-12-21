using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDammage : MonoBehaviour
{
    [SerializeField]
    private int dammage;

    public int GetDammage()
    {
        return dammage;
    }
}
