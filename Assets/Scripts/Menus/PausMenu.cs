//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PausMenu : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode pauseKey = KeyCode.Escape;

    [Header("Bools")]
    private bool paused;

    [Header("Game Objects")]
    public GameObject pauseMenu;

    private void Update()
    {
        if(Input.GetKeyDown(pauseKey) && paused)
        {
            Pause();
        }
        else if(Input.GetKeyDown(pauseKey) && !paused)
        {
            UnPause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
