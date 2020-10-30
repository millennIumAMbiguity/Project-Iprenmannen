using UnityEngine;

//millennIumAMbiguity
public class AIHitbox : MonoBehaviour
{

    public AI controller;
    public float damageMultiplier = 1f;


#if UNITY_EDITOR
    private void Awake() {
        if (controller == null) {
            Debug.LogWarning("'controller' is not set.");
        }
        if (damageMultiplier <= 0) {
            Debug.LogWarning("'damageMultiplier' is equal or less then 0");
        }
    }
#endif

    public void Hit(float damage) {
        controller.TakeDamage(damage * damageMultiplier);
    }
    public void Hit() {
        controller.TakeDamage(Stats.instance.playerHealth * damageMultiplier);
    }
}
