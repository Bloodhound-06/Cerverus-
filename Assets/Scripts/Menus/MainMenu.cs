using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

    public string GameScene1 = "GameScene1", OptionsMenu = "OptionsMenu";
    public void StartButton()
    {
        SceneManager.LoadScene(GameScene1);
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene(OptionsMenu);
    }

    public void ExitButton()
    {
        Application.Quit();
    }



}
