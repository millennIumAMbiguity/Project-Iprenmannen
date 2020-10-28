using UnityEngine;

public class AIHitbox : MonoBehaviour
{

    public AI controller;
    public float damageMultiplier = 1f;


#if UNITY_EDITOR
    private void Awake() {
        if (controller == null) {
            Debug.LogWarning("'controller' is not set.");
        }
    }
#endif

    public void Hit(float damage) {
        controller.TakeDamage(damage * damageMultiplier);
    }
    public void Hit() {
        controller.TakeDamage(Stats.playerHealth * damageMultiplier);
    }
}
