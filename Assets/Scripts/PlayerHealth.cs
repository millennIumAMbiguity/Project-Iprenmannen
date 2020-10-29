using UnityEngine;

//millennIumAMbiguity
public class PlayerHealth : Health
{
    public float healAmount = 0.02f;

    private void Awake() {
        Stats.playerHealth = maxHealth;
    }
    public override void Hit(float damage = 1f) {
        Stats.playerHealth -= 1f;
        Debug.Log(Stats.playerHealth);
        if (Stats.playerHealth <= 0) {
            GameOver();
        }
    }

    void FixedUpdate() {
        Stats.playerHealth += healAmount;
        if (Stats.playerHealth > maxHealth + Stats.playerHealthUpgrades) {
            Stats.playerHealth = maxHealth;
        }
    }
}
