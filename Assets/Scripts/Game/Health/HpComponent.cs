using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class HpComponent : MonoBehaviour
{
    [SerializeField] private float maxHp;
    private float currentHp;

    [SerializeField] private bool overhealAllowed;
    private void Start()
    {
        currentHp = maxHp;
    }

    public void ChangeValue(float difference)
    {
        currentHp += difference;
        if (currentHp < 0) { }
            currentHp = 0;
        if (currentHp > maxHp && !overhealAllowed)
            currentHp = maxHp;

    }

    public void AllowOverheal(bool value)
    {
        overhealAllowed = value;
    }
    
    public float GetCurrentHp()
    {
        return currentHp;
    }
}
