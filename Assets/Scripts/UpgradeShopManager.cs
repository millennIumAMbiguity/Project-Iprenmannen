using UnityEngine;

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
		Stats.instance.playerHealthUpgrades++;
		DisplayPlayerHealth();
	}

	public void UpgradePlayerDamage()
	{
		Stats.instance.playerDamage++;
		DisplayPlayerDamage();
	}

	private void DisplayPlayerHealth()
	{
		hp.text = "Health: " + (Stats.instance.playerHealthUpgrades + 2);
	}

	private void DisplayPlayerDamage()
	{
		dmg.text = "Damage: " + Stats.instance.playerDamage;
	}
}
