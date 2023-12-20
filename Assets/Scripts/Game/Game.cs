using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject gameOverCanva;
    public GameObject WinCanva;

    [SerializeField] Player player;
    [SerializeField] List<Enemy> enemyRoom1;
    [SerializeField] List<Enemy> enemyRoom2;
    [SerializeField] Door Room1;
    [SerializeField] Door Room2;

    bool pause = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (enemyRoom1.Count == 0)
        {
           Room1.OppenTheDoor();
            //Upgrade Weapon ?
        }

        if (enemyRoom2.Count == 0)
        {
            Room2.OppenTheDoor();
            WinCanva.SetActive(true);
        }

        if (player.live == 0) 
        {
            gameOverCanva.SetActive(true);
        } 
    }

    private void RemoveEnemy(Enemy ennemie)
    {
        if(Room1.Active) enemyRoom1.Remove(ennemie);
        if(Room2.Active) enemyRoom2.Remove(ennemie);

        ennemie.GetComponent<Health>().OnDeath -= RemoveEnemy;
    }

    private void OnEnable()
    {
        foreach (var ennemie in enemyRoom1)
        {
            ennemie.GetComponent<Health>().OnDeath += RemoveEnemy;
        }

        foreach (var ennemie in enemyRoom2)
        {
            ennemie.GetComponent<Health>().OnDeath += RemoveEnemy;
        }
    }

    private void OnDisable()
    {
        foreach (var ennemie in enemyRoom1)
        {
            ennemie.GetComponent<Health>().OnDeath -= RemoveEnemy;
        }

        foreach (var ennemie in enemyRoom2)
        {
            ennemie.GetComponent<Health>().OnDeath -= RemoveEnemy;
        }
    }



}
