using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("OfficeScene");
    }

    public void OpenTutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadSceneAsync("Mainmenu");
    }
}
