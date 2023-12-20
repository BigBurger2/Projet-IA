using NUnit.Framework.Internal;
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
    #region Events
    public event System.Action<Enemy> OnDeath;
    #endregion

    [SerializeField]
    [Range(1, 500)]
    private int HP;
    [SerializeField]
    [TagField]
    private List<string> weaponTag;
    [SerializeField]
    private GameObject destroyOnDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (weaponTag.Contains(collision.tag))
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
