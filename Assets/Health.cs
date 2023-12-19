using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*enum Tags
{
    Weapon,
    EnnemyWeapon
}*/
[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour
{
    [SerializeField]
    [Range(1, 500)]
    private int HP;
    [SerializeField]
    [TagField]
    private List<string> weaponTag;
    [SerializeField]
    private GameObject destroyOnDeath;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (weaponTag.Contains(collision.tag))
        {
            TakeDammage(collision.GetComponent<Weapon>().weaponData.dammage);
            collision.gameObject.SetActive(false);
        }
    }

    private void TakeDammage(int dammage)
    {
        HP -= dammage;
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(destroyOnDeath);
    }
}
