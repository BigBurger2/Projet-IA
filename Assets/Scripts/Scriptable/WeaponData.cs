using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Create Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    [TextArea]
    public string description;

    [Range(0f, 100f)]
    public int dammage;
    [Range(1f, 50f)]
    public float weaponSpeed;
    [Range(1, 50)]
    public int range;
    [Range(0f, 20f)]
    public float fireRate;

    public Sprite sprite;

    public GameObject prefabWeapon;
    [SerializeField] public TeamTag source;
}
