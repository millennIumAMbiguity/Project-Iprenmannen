using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Johan B.
public class WeaponBase : MonoBehaviour
{
    public float damage;
    public float range;
    Transform camtrans;

    int ignore;

    private void Awake() {
        camtrans = Camera.main.transform;
        ignore = ~(1 << LayerMask.NameToLayer("Invisible Wall"));
    }

    virtual public void RaycastHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(camtrans.position, camtrans.TransformDirection(Vector3.forward), out hit, range, ignore))
        {

            if (hit.collider.tag == "Enemy")
            {
                AIHitbox hitbox = hit.collider.GetComponent<AIHitbox>();

                if (hitbox != null)
                {
                    hitbox.Hit(damage * Stats.playerDamage);
                    Debug.Log("Enemy Hit");
                }
                else {
                    Debug.LogWarning("Enemy AIHitBox not found.");
                }
            }
#if UNITY_EDITOR
            else
            {
                Debug.Log("Hit tag: " + hit.collider.tag);
            }
            Debug.DrawRay(camtrans.position, camtrans.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 0.2f);
        } else
        {
            Debug.DrawRay(camtrans.position, camtrans.TransformDirection(Vector3.forward) * range, Color.red);
            Debug.Log("Miss");
#endif
        }
    }
}
