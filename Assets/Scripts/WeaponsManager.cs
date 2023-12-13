using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public Transform Target;
    public Transform Player;
    public Controller playerController;
    public List<GameObject> weaponsPrefabs;

    private Dictionary<GameObject, List<Weapon>> actualWeapons;
    private int nbChild;
    private int index;


    private void Awake()
    {
        InitAllWeapons();
    }

    public void InitAllWeapons()
    {
        foreach(var weapon in weaponsPrefabs)
        {
            Weapon wp = weapon.GetComponent<Weapon>();
            // Create the parent object
            GameObject parent = Instantiate(new GameObject(wp.weaponData.weaponName), transform);

            actualWeapons.Add(parent, new List<Weapon>());

            // Calc nb weapon
            float range = wp.weaponData.range;
            float speed = wp.weaponData.weaponSpeed;
            float fireRate = wp.weaponData.fireRate;

            int nbWeaponsToStore = Utils.CalcNbProjecctiles(range, speed, fireRate);

            for (int i = 0;  i < nbWeaponsToStore; i++)
            {
                GameObject temp = Instantiate(weapon, parent.transform);
                temp.SetActive(false);
                actualWeapons[parent].Add(temp.GetComponent<Weapon>());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
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
            foreach(var wp in weaponList.Value)
            {
                wp.startPos = Player.position;
                wp.Dir = (new Vector2(Player.position.x, Player.position.y) + playerController.vectorDir.normalized - wp.startPos).normalized;
            }
        }

    }
}
