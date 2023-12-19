using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LaunchGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;

    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 0;

    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }
}
