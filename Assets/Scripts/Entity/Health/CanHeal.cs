using System;
using UnityEngine;

[RequireComponent(typeof(HpComponent))]
public class CanHeal : MonoBehaviour
{
    private HpComponent hpComponent;

    private void Start()
    {
        hpComponent = GetComponent<HpComponent>();
    }

    public void Heal(float healAmount)
    {
        hpComponent.ChangeValue(+healAmount);
    }
}
