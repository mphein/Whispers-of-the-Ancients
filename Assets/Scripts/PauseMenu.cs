using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    //public GameObject onScreenUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!paused)
            {
                Pause();
                
            }
            else
            {
                Resume();
            }
        }
        
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //onScreenUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //onScreenUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    public void BacktoMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
