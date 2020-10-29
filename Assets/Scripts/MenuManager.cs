using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    public GameObject PausMenuUI;

    public FPSController playerControl;

    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }
    
    public void PauseGame()
    {
        PausMenuUI.SetActive(true);
        playerControl.enabled = false;
        Time.timeScale = 0f;
        UnlockMouse();
    }

    public void ResumeGame()
    {
        PausMenuUI.SetActive(false);
        playerControl.enabled = true;
        Time.timeScale = 1f;
        LockMouse();
        GameManager.GameIsPaused = false;
    }
    
    public void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void UnlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
}
