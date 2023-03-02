//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.Escape;
    readonly bool paused;
    public GameObject pauseMenu;
    readonly string optionsScene;

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey) && paused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(pauseKey) && !paused)
        {
            UnPause();
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
