using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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

    public void LoadGameScene3()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene(5);
    }
}
