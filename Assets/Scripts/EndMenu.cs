using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).ToString());
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(1).ToString());
    }
}
