using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Events
    public event System.Action<Enemy> OnDeath;
    #endregion

    [SerializeField]
    [Range(1, 500)]
    private int HP;
    [SerializeField]
    private string weaponTag;
    [SerializeField]
    private GameObject destroyOnDeath;


    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == weaponTag)
        {
            TakeDammage(collision.GetComponent<Weapon>().weaponData.dammage);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
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
        OnDeath?.Invoke(gameObject.GetComponent<Enemy>());
        Destroy(this.gameObject);
    }

    
}
