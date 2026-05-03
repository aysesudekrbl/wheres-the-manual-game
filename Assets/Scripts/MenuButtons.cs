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

    public void OpenSettings()
    {
        SceneManager.LoadSceneAsync("Settings");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadSceneAsync("Mainmenu");
    }
}
