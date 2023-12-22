using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpComponent : MonoBehaviour
{
    [SerializeField] private float maxHp;
    public float currentHp;

    [SerializeField] private bool overhealAllowed;

    [SerializeField] private Slider HPSlider;

    [SerializeField] public Material mat;

    private void Start()
    {
        currentHp = maxHp;
        if (gameObject.tag == "Player")
        {
            mat.SetFloat("Floatr", 5);
        }
        
    }

    public void ChangeValue(float difference)
    {
        currentHp += difference;

        if (gameObject.tag == "Player")
        {
            mat.SetFloat("Floatr", currentHp / maxHp * 5);
        }

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
