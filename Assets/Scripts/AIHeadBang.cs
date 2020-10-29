using UnityEngine;

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

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip hitSound;

    private void Awake() {
        neckStart = neck.localRotation.eulerAngles;
#if UNITY_EDITOR
        if (this.enabled) {
            this.enabled = false;
            Debug.LogWarning("Is enabled at startup, should be disabled.");
        }
#endif
    }

    public void Play(GameObject target) {
        if (!this.enabled) {
            this.target = target;
            t = 0f;
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
            if (!hit && t < hitTime +0.25f && Vector3.Distance(transform.position, target.transform.position) <= 2f) {
                audioSource.PlayOneShot(hitSound);
                target.GetComponent<Health>().Hit();
                hit = true;
            }

            if (t >= motion[motion.length - 1].time) {
                this.enabled = false;
            }

        }

    }
}
