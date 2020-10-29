using UnityEngine;

//millennIumAMbiguity
public class PlayerHealth : Health
{
    public float healAmount = 0.2f;

    private void Awake() {
        Stats.playerHealth = maxHealth;
    }
    public override void Hit(float damage = 1f) {
        Stats.playerHealth -= 1f;
#if UNITY_EDITOR
        Debug.Log( "player took damage and is now at HP: "+ Stats.playerHealth);
#endif
        if (Stats.playerHealth <= 0) {
            GameOver();
        }
    }

    void FixedUpdate() {
        Stats.playerHealth += healAmount * Time.fixedDeltaTime;
        if (Stats.playerHealth > maxHealth + Stats.playerHealthUpgrades) {
            Stats.playerHealth = maxHealth;
        }
    }
}
