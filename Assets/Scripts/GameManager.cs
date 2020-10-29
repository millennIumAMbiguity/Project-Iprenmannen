using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public MenuManager MenuManager;

    public static bool GameIsPaused;
    

    private void Start()
    {
        GameIsPaused = false;
        MenuManager.LockMouse();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GameIsPaused = !GameIsPaused;
            if (GameIsPaused)
            {
                MenuManager.PauseGame();
            }
            else 
            {  
                MenuManager.ResumeGame();
            }
        }

        
    }
}
