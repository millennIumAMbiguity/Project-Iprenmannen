using UnityEngine;

//millennIumAMbiguity
public class Health : MonoBehaviour
{
    public float maxHealth = 20;

    public virtual void Hit(float damage = 1f) {
        maxHealth -= damage;
        if (maxHealth <= 0) {
            GameOver();
        }
    }

    protected void GameOver() {
        Debug.Log("Game Over");
        Stats.time = Time.time;
    }

}
