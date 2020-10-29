using UnityEngine;

//millennIumAMbiguity
public class LockRotation : MonoBehaviour
{
    Quaternion iniRot;
    [Range(0, 1)]
    public float smoothing = 0.99f;
    float negSmoothing;
    void Start() {
        iniRot = transform.rotation;
        negSmoothing = 1 - smoothing;
    }

    void LateUpdate() {
        //transform.rotation = iniRot;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1)) {
            Quaternion newRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            transform.rotation = new Quaternion(
                newRotation[0] * negSmoothing + transform.rotation[0] * smoothing, 
                newRotation[1] * negSmoothing + transform.rotation[1] * smoothing, 
                newRotation[2] * negSmoothing + transform.rotation[2] * smoothing, 
                newRotation[3] * negSmoothing + transform.rotation[3] * smoothing);
        }
    }
}
