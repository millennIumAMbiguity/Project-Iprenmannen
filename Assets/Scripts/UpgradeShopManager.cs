using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeShopManager : MonoBehaviour
{
	public TMPro.TextMeshProUGUI hp;
	public TMPro.TextMeshProUGUI dmg;

	private void OnEnable()
	{
		DisplayPlayerDamage();
		DisplayPlayerHealth();
	}

	public void UpgradePlayerHealth()
	{
		Stats.playerHealthUpgrades++;
		DisplayPlayerHealth();
	}

	public void UpgradePlayerDamage()
	{
		Stats.playerDamage++;
		DisplayPlayerDamage();
	}

	private void DisplayPlayerHealth()
	{
		hp.text = "Health: " + (Stats.playerHealthUpgrades + 2);
	}

	private void DisplayPlayerDamage()
	{
		dmg.text = "Damage: " + Stats.playerDamage;
	}
}
