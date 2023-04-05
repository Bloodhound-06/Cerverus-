//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.Escape; //the key to escape
    public bool paused; //is the game paused
    public GameObject pauseMenu; //the pause menu game object
    public string optionsScene; //the options menu


    private void Start()
    {
        UnPause(); //calls Un Pause
        paused = false; //sets paused to false
    }
    private void Update()
    {
        if (Input.GetKeyDown(pauseKey) && paused) //if the game is paused and the pause key is pressed
        {
            UnPause(); //calls Un Pause
        }
        else if (Input.GetKeyDown(pauseKey) && !paused) //if the game issnt paused and the pause key is pressed
        {
            Pause(); //calls pause
        }
    }

    public void Resume()
    {
        UnPause(); //calls un pause
    }

    public void Options()
    {
        SceneManager.LoadScene(optionsScene); //sets the scene to options scene
    }

    public void ExitGame() 
    {
        Application.Quit(); //exits the game
    }
    public void Pause()
    {
        paused = true; //sets paused to true
        pauseMenu.SetActive(true); //sets the pause menu game object to active
        Time.timeScale = 0; //stops calculations from scripts
    }

    public void UnPause()
    {
        paused = false; //sets paused to fals
        pauseMenu.SetActive(false); //hides the pause menu game object
        Time.timeScale = 1; //starts calculations from scripts
    }
}