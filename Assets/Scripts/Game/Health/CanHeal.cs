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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        if (item != null)
        {
            Heal(item.GetHeal());
        }
    }

}
