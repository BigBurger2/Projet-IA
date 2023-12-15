using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ennemiesSpawner : MonoBehaviour
{

    [SerializeField] Enemy ennemies;
    [SerializeField] GameObject Player;
    [SerializeField] int nbrEnnemy;

    void Start()
    {
        ennemies.newEnemy(ennemies, nbrEnnemy);
    }
}