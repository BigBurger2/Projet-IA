using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject nextLevelCanva;
    public GameObject gameOverCanva;
    public TMPro.TextMeshPro pointText;

    [SerializeField] Player player;
 
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
            nextLevelCanva.SetActive(true);
            DisplayPoint();
        }

        if (player.live == 0) 
        {
            //display canva game over
            DisplayPoint();
        } 
    }

    

    private void DisplayPoint()
    {
        pointText.text = player.point.ToString();
    }


}
