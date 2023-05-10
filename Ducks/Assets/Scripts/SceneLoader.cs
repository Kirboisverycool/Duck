using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameScene1()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGameScene2()
    {
        SceneManager.LoadScene(3);
    }

    public void SecretGameScene()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadEndGameScene()
    {
        SceneManager.LoadScene(4);
    }
}
