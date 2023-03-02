//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.Escape;
    public bool paused;
    public GameObject pauseMenu;
    readonly string optionsScene;


    private void Start()
    {
        UnPause();
        paused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(pauseKey) && paused)
        {
            UnPause();
        }
        else if (Input.GetKeyDown(pauseKey) && !paused)
        {
            Pause();
        }
    }

    public void Resume()
    {
        UnPause();
    }

    public void Options()
    {
        SceneManager.LoadScene(optionsScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
