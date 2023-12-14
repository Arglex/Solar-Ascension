using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject pauseCanvas;

    private bool gamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        ToggleGamePaused();
        if (gamePaused)
        {
            Time.timeScale = 0;
            playerMovement.enabled = false;
            pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            playerMovement.enabled = true;
            pauseCanvas.SetActive(false);
        }
    }

    private void ToggleGamePaused()
    {
        if (gamePaused)
        {
            Cursor.visible = false;
            gamePaused = false;
        }
        else
        {
            Cursor.visible = true;
            gamePaused = true;
        }
    }
    public void RestartStartGame()
    {
        TogglePauseGame();
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
