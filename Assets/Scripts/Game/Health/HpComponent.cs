using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.UI;

public class HpComponent : MonoBehaviour
{
    [SerializeField] private float maxHp;
    public float currentHp;

    [SerializeField] private bool overhealAllowed;

    [SerializeField] private Slider HPSlider;
    private void Start()
    {
        currentHp = maxHp;
    }

    public void ChangeValue(float difference)
    {
        currentHp += difference;
        if (HPSlider != null) HPSlider.value = currentHp/maxHp;

        if (currentHp < 0)
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
