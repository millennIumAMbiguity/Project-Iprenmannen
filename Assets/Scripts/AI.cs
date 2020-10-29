using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI : MonoBehaviour
{

    NavMeshAgent agent;
    float speed;
    GameObject[] go;
    public float hp = 20;
    public GameObject parent;
    public AIDeath aiDeath;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        go = GameObject.FindGameObjectsWithTag("Player");
        agent.speed += Random.Range(-0.1f,0.1f);
        speed = agent.speed;
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
        if (agent.speed < speed) {
            agent.speed += 0.002f;
        }

    }

    public void TakeDamage(float damage) {
        hp -= damage;
        agent.speed -= damage / 100f;
        if (hp <= 0 && this.enabled) {
            agent.speed = 0;
            agent.isStopped = true;
            aiDeath.Die();
            this.enabled = false;
        }
    }

    public void Kill() {
        Destroy(parent);
    }


}
