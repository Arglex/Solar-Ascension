using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject pauseCanvas;

    private bool gamePaused = false;
    private void Start()
    {
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        ToggleGamePaused();
        if (gamePaused)
        {
            playerMovement.enabled = false;
            pauseCanvas.SetActive(true);
        }
        else
        {
            playerMovement.enabled = true;
            pauseCanvas.SetActive(false);
        }
    }

    private void ToggleGamePaused()
    {
        if (gamePaused)
        {
            gamePaused = false;
        }
        else
        {
            gamePaused = true;
        }
    }
}
