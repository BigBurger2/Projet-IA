using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*enum Tags
{
    Weapon,
    EnnemyWeapon
}*/
public class Health : MonoBehaviour
{
    [SerializeField]
    [Range(1, 500)]
    private int HP;
    [SerializeField]
    [TagField]
    private string weaponTag;
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
        if (collision.tag == weaponTag)
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
