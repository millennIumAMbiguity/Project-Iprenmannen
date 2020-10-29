﻿using UnityEngine;

//millennIumAMbiguity
public class AIHeadBang : MonoBehaviour
{
    public Transform head;
    public Transform neck;

    public AnimationCurve motion;

    public float hitTime;

    GameObject target;
    bool hit;
    float t = 0;

    Vector3 neckStart;

    private void Awake() {
        neckStart = neck.localRotation.eulerAngles;
    }

    public void Play(GameObject target) {
        if (!this.enabled) {
            this.target = target;
            t = 0;
            hit = false;
            this.enabled = true;
        }
    }

    void FixedUpdate() {

        float eva = motion.Evaluate(t);
        Vector3 rot = eva * (new Vector3((transform.position.z - target.transform.position.z), 0,(transform.position.x - target.transform.position.x)).normalized);

        head.localRotation = Quaternion.Euler(rot);
        neck.localRotation = Quaternion.Euler(rot + neckStart);

        t += Time.fixedDeltaTime;

        if (t >= hitTime) {
            if (!hit) {
                target.GetComponent<Health>().Hit();
                hit = true;
            }

            if (t >= motion[motion.length - 1].time) {
                this.enabled = false;
            }

        }

    }
}
