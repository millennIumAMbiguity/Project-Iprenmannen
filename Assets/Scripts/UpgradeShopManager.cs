using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeShopManager : MonoBehaviour
{
	public static bool ShopIsOpen = false;

	public GameObject shopMenuUI;

	public GameObject PlayerControllerScript;

	private void Start()
	{
		PlayerControllerScript = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if (ShopIsOpen)
			{
				CloseShop();
			}
			else
			{
				OpenShop();
				
			}
		}
	}

	void UpgradePlayerHealth()
	{
		//TODO: Implement code to upgrade player health
		Debug.Log("Pressed HP button");
	}

	void UpgradePlayerDamage()
	{
		//TODO: Implement code to upgrade player damage
		Debug.Log("Pressed DMG button");
	}

	void CloseShop()
	{
		shopMenuUI.SetActive(false);
		PlayerControllerScript.GetComponent<FPSController>().enabled = true;
		Time.timeScale = 1f;
		ShopIsOpen = false;
		Debug.Log("Exit shop");
	}
	void OpenShop()
    {
     	shopMenuUI.SetActive(true);
        PlayerControllerScript.GetComponent<FPSController>().enabled = false;
        Time.timeScale = 0f;
        ShopIsOpen = true;
    }
}
