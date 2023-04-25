using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LoadingScreen load;
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void StartGame()
    {
        load.LoadScene(2);
    }

    public void ResetMainMenu()
    {
        load.LoadScene(1);
    }
    public void Skip()
    {
        load.LoadScene(3);
    }
}
