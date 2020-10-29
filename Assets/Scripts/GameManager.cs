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
        inShopArea = false;
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
            if(!ShopIsOpen && Input.GetButtonDown("shopButton"))
            {
                menuManager.OpenShopMenu();
            }

            if (ShopIsOpen && Input.GetButtonDown("shopButton"))
            {
                menuManager.CloseShopMenu();
            }
        }
    }
}
