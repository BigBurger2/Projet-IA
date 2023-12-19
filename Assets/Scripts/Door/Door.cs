using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject doors;
    [SerializeField] List<Enemy> enemy;

    void Start()
    {
        
    }

    void Update()
    {
        if (enemy.Count == 0) OppenTheDoor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doors.SetActive(true);
            if (enemy != null)
            {
                foreach (var ennemie in enemy)
                {
                    ennemie.Agressive = true;
                    
                }
            }
        }
        
    }

    private void OppenTheDoor()
    {
        doors.SetActive(false);
    }

    private void RemoveEnemy(Enemy ennemie)
    {
        enemy.Remove(ennemie);
        ennemie.GetComponent<Health>().OnDeath -= RemoveEnemy;
    }

    private void OnEnable()
    {
        foreach(var ennemie in enemy)
        {
            ennemie.GetComponent<Health>().OnDeath += RemoveEnemy;
        }
    }

    private void OnDisable()
    {
        foreach (var ennemie in enemy)
        {
            ennemie.GetComponent<Health>().OnDeath -= RemoveEnemy;
        }
    }

}
