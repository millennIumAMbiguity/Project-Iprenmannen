using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Johan B.
public class WeaponBase : MonoBehaviour
{
    public float damage;
    public float range;

    virtual public void RaycastHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.tag == "Enemy")
            {
                AIHitbox hitbox = hit.collider.GetComponent<AIHitbox>();

                if (hitbox != null)
                {
                    hitbox.Hit(damage);
                    Debug.Log("Enemy Hit");
                }
                else
                    Debug.Log("Enemy AIHitBox not found.");
            }
            else
            {
                Debug.Log("Hit");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Miss");
        }
    }
}
