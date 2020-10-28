using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject[] go;
    public float hp = 20;
    public GameObject parent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        go = GameObject.FindGameObjectsWithTag("Player");
    }

    private void FixedUpdate() {
        float dist = 99999;
        foreach (GameObject item in go) {
            float d = Vector3.Distance(transform.position, item.transform.position);
            if (d < dist) {
                dist = d;
                agent.SetDestination(item.transform.position);
            }
        }
        if (dist < 2f) {
            agent.isStopped = true;
        } else {
            agent.isStopped = false;
        }
    }

    public void TakeDamage(float damage) {
        hp -= damage;
        if (hp <= 0) {
            Kill();
        }
    }

    void Kill() {
        Destroy(parent);
    }


}
