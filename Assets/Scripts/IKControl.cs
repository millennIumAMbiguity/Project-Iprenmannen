using UnityEngine;

public class IKControl : MonoBehaviour
{


    public Transform[] targets;
    public float walkDistance = 3f;
    public float maxDistance = 4f;
    public float hightAngle = -1;

    float angle;

    void Start() {
        angle = 2 * Mathf.PI / targets.Length;
    }

    //a callback for calculating IK
    void FixedUpdate() {

        float currentAngle = 0;

        for (int i = 0; i < targets.Length; i++) {
            RaycastHit hit;
            Vector3 direction = transform.TransformDirection(new Vector3(-Mathf.Sin(currentAngle), hightAngle, -Mathf.Cos(currentAngle)));
            currentAngle += angle;
            if (
                #if UNITY_EDITOR
                targets[i] != null &&
                #endif
                Physics.Raycast(transform.position, direction, out hit, maxDistance)) {

                #if UNITY_EDITOR
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow);
                #endif

                if (Vector3.Distance(hit.point, targets[i].position) > walkDistance) {
                    targets[i].position = hit.point + (1f + UnityEngine.Random.Range(-1f,0f))*( hit.point - targets[i].position);
#if UNITY_EDITOR
                    Debug.DrawLine(targets[i].position, targets[i].position + new Vector3(0,0.3f,0),Color.green, 0.5f);
#endif
                }
            }
            #if UNITY_EDITOR
            else {
                Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
            }
            #endif
        }
    }
}