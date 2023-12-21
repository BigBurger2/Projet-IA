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

    private bool invincible = false;

    [SerializeField] private TeamTag team;

    public bool Invincible { get => invincible; set => invincible = value; }

    [SerializeField] private GameObject fx;

    private void Start()
    {
        hpComponent = GetComponent<HpComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible)
        {
            var projComp = collision.gameObject.GetComponent<Weapon>();
            if (projComp != null)
            {
                if (projComp.GetSource() != team)
                {
                    
                Debug.Log("boom");
                hpComponent.ChangeValue(-projComp.weaponData.dammage);
                fx.transform.position = collision.transform.position;
                
                Instantiate(fx);
                collision.gameObject.SetActive(false);
                }
            }

            if (hpComponent.GetCurrentHp() <= 0)
            {
                gameObject.GetComponent<Entity>()?.OnDeath();
            }
            
        }
    }
}
