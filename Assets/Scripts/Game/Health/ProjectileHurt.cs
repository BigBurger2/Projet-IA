using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Need for working collisions 
[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Rigidbody2D))]
//Need else we got no values to change
[RequireComponent(typeof(HpComponent))]
public class ProjectileHurt : MonoBehaviour
{
    private HpComponent hpComponent;
    
    [SerializeField] private TeamTag team; 
    private void Start()
    {
        hpComponent = GetComponent<HpComponent>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var projComp = collision.gameObject.GetComponent<Weapon>();
        if (projComp != null)
        {
            if (projComp.GetSource() != team)
            {
                hpComponent.ChangeValue(-projComp.weaponData.dammage);
                collision.gameObject.SetActive(false);
            }

            if (hpComponent.GetCurrentHp() <= 0)
            {
                //IMA DEAD
                Debug.Log("deadge");
                gameObject.SetActive(false);
            }
        }
    }
}
