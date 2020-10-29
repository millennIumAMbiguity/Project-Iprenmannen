using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    public GameObject PausMenuUI;
    public GameObject ShopMenuUi;

    public FPSController playerControl;

    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }

    public void OpenPauseMenu()
    {
        PausMenuUI.SetActive(true);
        PauseGame();
    }

    public void ClosePauseMenu()
    {
        PausMenuUI.SetActive(false);
        ResumeGame();
    }

    public void OpenShopMenu()
    {
        ShopMenuUi.SetActive(true);
        PauseGame();
        GameManager.ShopIsOpen = true;
    }

    public void CloseShopMenu()
    {
        ShopMenuUi.SetActive(false);
        ResumeGame();
        GameManager.ShopIsOpen = false;
    }
    
    public void PauseGame()
    {
        playerControl.enabled = false;
        Time.timeScale = 0f;
        UnlockMouse();
        GameManager.GameIsPaused = true;
    }

    public void ResumeGame()
    {
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
