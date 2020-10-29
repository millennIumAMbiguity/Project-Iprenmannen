using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeShopManager : MonoBehaviour
{
	void UpgradePlayerHealth()
	{
		Stats.playerHealthUpgrades++;
		Debug.Log("Pressed HP button");
	}

	void UpgradePlayerDamage()
	{
		Stats.playerDamage++;
		Debug.Log("Pressed DMG button");
	}
}
