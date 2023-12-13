using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(ChangeScene());
    }

    public void QuitGame()
    {
        Debug.Log("Application Quitted");
        Application.Quit();
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
