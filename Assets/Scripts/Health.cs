using UnityEngine;

//millennIumAMbiguity
public class Health : MonoBehaviour
{
    public float maxHealth = 20;

    public virtual void Hit(float damage = 1f) {
        maxHealth -= damage;
        if (maxHealth <= 0f) {
            GameOver();
        }
    }

    protected void GameOver() {
        if (Stats.time != 0f)
            return;
        Debug.Log("Game Over");
        Stats.time = Time.time;
        AutoFade.LoadLevel(2, 2f, 2f, Color.black);
    }

}
