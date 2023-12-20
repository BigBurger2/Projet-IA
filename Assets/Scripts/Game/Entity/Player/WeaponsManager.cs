using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Structure qui stocke les copies des armes pour l'object pool et la référence à sa coroutine
struct WeaponList
{
    public float LastTimeStopShoot;
    public int index;
    public int nbWeapons;
    public List<Weapon> weapons;
    public float TimeReload;
    public IEnumerator Coroutine;

    public bool fired;
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
    [SerializeField]
    private InputManager InputManager;

    private Dictionary<GameObject, WeaponList> actualWeapons;
    private Dictionary<GameObject, WeaponList> modifiedWeapons;

    private Vector2 lastClickMouse;


    //private int index = 0;

    private float TimeStopShoot = 0;

    private void Awake()
    {
        actualWeapons = new Dictionary<GameObject, WeaponList>();
        modifiedWeapons = new Dictionary<GameObject, WeaponList>();
    }

    private void Start()
    {
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
            GameObject parent = new GameObject(data.weaponName);
            parent.transform.parent = transform;

            // Associe une instance de coroutine à la weapon afin de gérer son fireRate
            WeaponList tmpWpList = new WeaponList();
            tmpWpList.Coroutine = FireCoroutine(parent, data);
            tmpWpList.weapons = new List<Weapon>();
            tmpWpList.index = 0;
            tmpWpList.TimeReload = 1 / data.fireRate;
            tmpWpList.LastTimeStopShoot = 0;
            tmpWpList.fired = true;
            

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

            if (weaponList.Value.fired)
            {
                WeaponList temp = weaponList.Value;
                temp.LastTimeStopShoot = Time.time;
                temp.fired = false;
                modifiedWeapons[weaponList.Key] = temp;
            }

        }
        actualWeapons = modifiedWeapons;
    }


    public IEnumerator FireCoroutine(GameObject parent, WeaponData weaponData)
    {
        while (true)
        {

            WeaponList wpList = modifiedWeapons[parent];

            if (wpList.fired)
            {
                //Debug.Log(parent.name + " : " + wpList.index + " : " + wpList.nbWeapons);
                lastClickMouse = Camera.main.ScreenToWorldPoint(InputManager.input.Player.MousePosition.ReadValue<Vector2>());

                Transform temp = parent.transform.GetChild(wpList.index);
                temp.position = Player.position;

                wpList.weapons[wpList.index].Fire(lastClickMouse - new Vector2(temp.position.x, temp.position.y));


                wpList.index++;
                wpList.index %= wpList.nbWeapons;

                modifiedWeapons[parent] = wpList;

                yield return new WaitForSeconds((1f / weaponData.fireRate));
            }
            else
            {
                if (Time.time - wpList.LastTimeStopShoot > wpList.TimeReload)
                {
                    wpList.fired = true;
                    modifiedWeapons[parent] = wpList;
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
