using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

    public string GameScene1 = "GameScene1", OptionsMenu = "OptionsMenu";
    public void StartButton()
    {
        SceneManager.LoadScene(GameScene1); //sets the scene to GameScene1
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene(OptionsMenu); //sets the scene to options menu
    }

    public void ExitButton()
    {
        Application.Quit(); //quits the aplication
    }



}
