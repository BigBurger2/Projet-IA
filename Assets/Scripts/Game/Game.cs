using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject menuPause;

    bool pause = false;
    int enemyNbr;

    private void Start()
    {
        enemyNbr = 10;
    }

    private void Update()
    {
        if (enemyNbr == 0)
        {
            //panneau lvl suivant
        }
    }

    private void RestartGame()
    {

    }

   


}
