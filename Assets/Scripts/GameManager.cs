using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public MenuManager MenuManager;

    public static bool GameIsPaused;
    public static bool ShopIsOpen;
    public bool inShopArea;

    private void Start()
    {
        GameIsPaused = false;
        ShopIsOpen = false;
        inShopArea = false;
        MenuManager.LockMouse();
    }

    private void Update()
    {
        //Checking conditions for PauseMenu.
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                MenuManager.ClosePauseMenu();
            }
            else 
            {  
                MenuManager.OpenPauseMenu();
            }
        }
        
        //Checking conditions for ShopMenu.
        if (inShopArea)
        {
            if(!ShopIsOpen && Input.GetButtonDown("shopButton"))
            {
                MenuManager.OpenShopMenu();
            }

            if (ShopIsOpen && Input.GetButtonDown("shopButton"))
            {
                MenuManager.CloseShopMenu();
            }
        }
    }
}
