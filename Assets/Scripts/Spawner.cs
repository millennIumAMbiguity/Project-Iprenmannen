using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnLocations;

    public GameObject[] spawnNpcs;

    public float cooldown = 30;
    float lastSpawn = 0f;

    public float difficulty = 10;

    public float difficultyChange = 1f;

    void Start() {
        lastSpawn = -cooldown;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > lastSpawn + cooldown) {
            lastSpawn = Time.time;

            difficulty += difficultyChange;

            int spawnPos = Random.Range(0, spawnLocations.Length);

            int spawnAmount = (int)(0.5f + Mathf.Sqrt(difficulty));
            for (int i = 0; i < spawnAmount; i++) {
                Instantiate(spawnNpcs[Random.Range(0, spawnNpcs.Length)], spawnLocations[spawnPos].position, Quaternion.Euler(0,Random.Range(0,360),0));
            }
            Debug.Log("Spawned " + spawnAmount + " NPCs at " + spawnLocations[spawnPos].position.ToString());
        }
    }
}
