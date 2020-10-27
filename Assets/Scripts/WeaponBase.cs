using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Johan B.
public class WeaponBase : MonoBehaviour
{
    public int damage;
    public float range;

    virtual public void RaycastHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.tag == "Enemy")
            {
                //GetComponent Enemy HP (Send damage)
                Debug.Log("Enemy Hit");
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
