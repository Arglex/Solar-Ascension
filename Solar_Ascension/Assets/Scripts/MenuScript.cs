using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
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
}
