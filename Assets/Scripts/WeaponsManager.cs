using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Structure qui stocke les copies des armes pour l'object pool et la référence à sa coroutine
struct WeaponList
{
    public int nbWeapons;
    public List<Weapon> weapons;
    public IEnumerator Coroutine;
}

public class WeaponsManager : MonoBehaviour
{
    public Transform Target;
    public Transform Player;
    public Controller playerController;
    [SerializeField]
    private List<GameObject> weaponsPrefabs;

    private Dictionary<GameObject, WeaponList> actualWeapons;

    private int index = 0;

    private void Awake()
    {
        actualWeapons = new Dictionary<GameObject, WeaponList>();
        InitAllWeapons();
    }

    public void InitAllWeapons()
    {
        // Génère les copies nécessaire et associe une instance de coroutine pour chaque arme
        foreach(var weapon in weaponsPrefabs)
        {
            Weapon wp = weapon.GetComponent<Weapon>();
            // Create the parent object
            GameObject parent = Instantiate(new GameObject(wp.weaponData.weaponName), transform);

            // Associe une instance de coroutine à la weapon afin de gérer son fireRate
            WeaponList tmpWpList = new WeaponList();
            tmpWpList.Coroutine = FireCoroutine(parent, wp.weaponData);
            tmpWpList.weapons = new List<Weapon>();
            

            // Calc nb weapon
            float range = wp.weaponData.range;
            float speed = wp.weaponData.weaponSpeed;
            float fireRate = wp.weaponData.fireRate;

            int nbWeaponsToStore = Utils.CalcNbProjectiles(range, speed, fireRate);

            // Instantiation de toutes les copies nécessaires
            for (int i = 0;  i < nbWeaponsToStore; i++)
            {
                GameObject temp = Instantiate(weapon, parent.transform);
                temp.SetActive(false);
                tmpWpList.weapons.Add(temp.GetComponent<Weapon>());
            }

            // Ajout de la paire Weapon et WeaponList
            tmpWpList.nbWeapons = nbWeaponsToStore;
            actualWeapons.Add(parent, tmpWpList);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        /*Transform temp = transform.GetChild(index);
        temp.position = Player.position;
        Weapon weaponMove = temp.GetComponent<Weapon>();

        //weaponMove.SetTarget(new Vector2(Player.position.x, Player.position.y) + playerController.vectorDir.normalized * weaponMove.range);
        weaponMove.startPos = Player.position;
        weaponMove.Dir = (new Vector2(Player.position.x, Player.position.y) + playerController.vectorDir.normalized - new Vector2(temp.position.x, temp.position.y)).normalized;
        temp.gameObject.SetActive(true);
        weaponMove.fired = true;

        index++;
        index %= nbChild;*/

        foreach (var weaponList in actualWeapons)
        {

            StartCoroutine(weaponList.Value.Coroutine);
            
        }

    }

    public void Stop()
    {
        foreach (var weaponList in actualWeapons)
        {
            StopCoroutine(weaponList.Value.Coroutine);
        }
    }


    public IEnumerator FireCoroutine(GameObject parent, WeaponData weaponData)
    {
        
        while (true)
        {
            Transform temp = parent.transform.GetChild(index);
            temp.position = Player.position;

            actualWeapons[parent].weapons[index].Fire(playerController.vectorDir);


            index++;
            index %= actualWeapons[parent].nbWeapons;
            yield return new WaitForSeconds(1f / weaponData.fireRate);
        }
    }
}
