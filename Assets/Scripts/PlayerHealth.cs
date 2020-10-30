using UnityEngine;

//millennIumAMbiguity
public class PlayerHealth : Health
{
    public float healAmount = 0.2f;

    private void Awake() {
        if (Stats.instance == null) {
            Stats.instance = new Stats.data();
        }
        Stats.instance.playerHealth = maxHealth;
    }
    public override void Hit(float damage = 1f) {
        Stats.instance.playerHealth -= 1f;
#if UNITY_EDITOR
        Debug.Log( "player took damage and is now at HP: "+ Stats.instance.playerHealth);
#endif
        if (Stats.instance.playerHealth <= 0) {
            GameOver();
        }
    }

    void FixedUpdate() {
        Stats.instance.playerHealth += healAmount * Time.fixedDeltaTime;
        if (Stats.instance.playerHealth > maxHealth + Stats.instance.playerHealthUpgrades) {
            Stats.instance.playerHealth = maxHealth;
        }
    }
}
