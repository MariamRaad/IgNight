using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool paused = false;
    
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        
        if (paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;

            AudioListener.pause = true;
        }

        if (!paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;

            AudioListener.pause = false;
        }
    }

    public void Continue()
    {
        paused = false;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
