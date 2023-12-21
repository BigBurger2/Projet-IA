using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int healAmount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetHeal()
    {
        Destroy(gameObject);
        return healAmount;
    }
}
