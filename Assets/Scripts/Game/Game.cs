using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject gameOverCanva;
    public GameObject WinCanva;

    [SerializeField] GameObject player;
    [SerializeField] List<Entity> enemyRoom1;
    [SerializeField] List<Entity> enemyRoom2;
    [SerializeField] List<Entity> BossRoom;
    [SerializeField] Door Room1;
    [SerializeField] Door Room2;
    [SerializeField] Door BossDoor;
    HpComponent playerLife;
    [SerializeField] PauseManager pauseManager;

    bool pause = false;
    private void Start()
    {
        playerLife = player.GetComponent<HpComponent>();
    }



    private void FixedUpdate()
    {
        if (enemyRoom1.Count == 0)
        {
           Room1.OppenTheDoor();
            //Upgrade Weapon ?
        }

        if (enemyRoom2.Count == 0)
        {
            Room2.OppenTheDoor();
        }
        
        if (BossRoom.Count == 0)
        {
            BossDoor.OppenTheDoor();
            WinCanva.SetActive(true);
            pauseManager.Stop();

        }

        if (playerLife.GetCurrentHp() <= 0) 
        {
            gameOverCanva.SetActive(true);
            pauseManager.Stop();
        } 
    }

    private void RemoveEnemy(Entity ennemie)
    {
        if(Room1.Active) enemyRoom1.Remove(ennemie);
        if(Room2.Active) enemyRoom2.Remove(ennemie);
        if(BossDoor.Active) BossRoom.Remove(ennemie);

        ennemie.OnDeathEvent -= RemoveEnemy;
    }

    private void OnEnable()
    {
        foreach (var ennemie in enemyRoom1)
        {
            ennemie.OnDeathEvent += RemoveEnemy;
        }

        foreach (var ennemie in enemyRoom2)
        {
            ennemie.OnDeathEvent += RemoveEnemy;
        }
        
        foreach (var ennemie in BossRoom)
        {
            ennemie.OnDeathEvent += RemoveEnemy;
        }
    }

    private void OnDisable()
    {
        foreach (var ennemie in enemyRoom1)
        {
            ennemie.OnDeathEvent -= RemoveEnemy;
        }

        foreach (var ennemie in enemyRoom2)
        {
            ennemie.OnDeathEvent -= RemoveEnemy;
        }

        foreach (var ennemie in BossRoom)
        {
            ennemie.OnDeathEvent -= RemoveEnemy;
        }
    }



}
