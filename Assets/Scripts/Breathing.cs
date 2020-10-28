using UnityEngine;

//millennIumAMbiguity
public class Breathing : MonoBehaviour
{
    public float speed = 1f;
    public float randOffset = 0.2f;
    public float sizeDifd = 0.3f;

    Vector3 startScale;

    void Start() {
        randOffset = Random.Range(-randOffset, randOffset);
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update() {
        transform.localScale = startScale + startScale * Mathf.Sin(Time.time * speed + randOffset) * sizeDifd;
    }
}
