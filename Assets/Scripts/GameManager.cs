using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public MenuManager menuManager;

    public static bool GameIsPaused;
    public static bool ShopIsOpen;
    public bool inShopArea;

    private void Start()
    {
        GameIsPaused = false;
        ShopIsOpen = false;
        inShopArea = true;
        menuManager.LockMouse();
    }

    private void Update()
    {
        //Checking conditions for PauseMenu.
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                menuManager.ClosePauseMenu();
            }
            else 
            {  
                menuManager.OpenPauseMenu();
            }
        }
        
        //Checking conditions for ShopMenu.
        if (inShopArea)
        {
            if(!ShopIsOpen && Input.GetKeyDown(KeyCode.E))
            {
                menuManager.OpenShopMenu();
            }
            else if (ShopIsOpen && Input.GetKeyDown(KeyCode.E))
            {
                menuManager.CloseShopMenu();
            }
        }
    }
}
