using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Structure qui stocke les copies des armes pour l'object pool et la référence à sa coroutine
struct WeaponList
{
    public int index;
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
    private GameObject weaponPrefab;
    [SerializeField]
    private List<WeaponData> weaponDatas;

    private Dictionary<GameObject, WeaponList> actualWeapons;
    private Dictionary<GameObject, WeaponList> modifiedWeapons;

    //private int index = 0;

    private void Awake()
    {
        actualWeapons = new Dictionary<GameObject, WeaponList>();
        modifiedWeapons = new Dictionary<GameObject, WeaponList>();
        InitAllWeapons();
    }

    public void InitAllWeapons()
    {
        // Génère les copies nécessaire et associe une instance de coroutine pour chaque arme
        foreach(var data in weaponDatas)
        {
            Weapon wp = weaponPrefab.GetComponent<Weapon>();
            wp.weaponData = data;
            // Create the parent object
            GameObject parent = Instantiate(new GameObject(data.weaponName), transform);

            // Associe une instance de coroutine à la weapon afin de gérer son fireRate
            WeaponList tmpWpList = new WeaponList();
            tmpWpList.Coroutine = FireCoroutine(parent, data);
            tmpWpList.weapons = new List<Weapon>();
            tmpWpList.index = 0;
            

            // Calc nb weapon
            float range = wp.weaponData.range;
            float speed = wp.weaponData.weaponSpeed;
            float fireRate = wp.weaponData.fireRate;

            int nbWeaponsToStore = Utils.CalcNbProjectiles(range, speed, fireRate);

            // Instantiation de toutes les copies nécessaires
            for (int i = 0;  i < nbWeaponsToStore; i++)
            {
                GameObject temp = Instantiate(weaponPrefab, parent.transform);
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

        modifiedWeapons = new Dictionary<GameObject, WeaponList>(actualWeapons);
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
            actualWeapons = modifiedWeapons;
        }
    }


    public IEnumerator FireCoroutine(GameObject parent, WeaponData weaponData)
    {
        
        while (true)
        {
            WeaponList wpList = modifiedWeapons[parent];
            //Debug.Log(parent.name + " : " + wpList.index + " : " + wpList.nbWeapons);

            Transform temp = parent.transform.GetChild(wpList.index);
            temp.position = Player.position;

            wpList.weapons[wpList.index].Fire(playerController.vectorDir);


            wpList.index++;
            wpList.index %= wpList.nbWeapons;

            modifiedWeapons[parent] = wpList;

            for (int i=0; i < 10; i++)
            {
                yield return new WaitForSeconds((1f / weaponData.fireRate)/10);
            }
        }
    }
}
