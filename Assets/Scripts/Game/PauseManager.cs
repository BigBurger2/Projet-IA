using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject menuPause;
    private bool pause = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Play()
    {
        Time.timeScale = 1;
        pause = false;
    }

    public void Stop()
    {
        Time.timeScale = 0;
        pause = true;
    }


    public void Pause()
    {
        if (pause)
        {
            Time.timeScale = 1;
            menuPause.SetActive(false);
            pause = false;
        }
        else
        {
            Time.timeScale = 0;
            menuPause.SetActive(true);
            pause = true;
        }
    }

}
