using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public Transform Target;
    public Transform Player;
    public Controller playerController;

    private Rigidbody2D[] allWeaponsRB;
    private int nbChild;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        allWeaponsRB = GetComponentsInChildren<Rigidbody2D>();
        nbChild = allWeaponsRB.Length;
        index = 0;


        for (int i = 0; i < nbChild; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        Transform temp = transform.GetChild(index);
        temp.position = Player.position;
        WeaponMove weaponMove = temp.GetComponent<WeaponMove>();

        //weaponMove.SetTarget(new Vector2(Player.position.x, Player.position.y) + playerController.vectorDir.normalized * weaponMove.range);
        weaponMove.startPos = Player.position;
        weaponMove.Dir = (new Vector2(Player.position.x, Player.position.y) + playerController.vectorDir.normalized - new Vector2(temp.position.x, temp.position.y)).normalized;
        temp.gameObject.SetActive(true);
        weaponMove.fired = true;

        index++;
        index %= nbChild;
    }
}
