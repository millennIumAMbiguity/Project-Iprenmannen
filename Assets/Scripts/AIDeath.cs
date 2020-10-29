using UnityEngine;

//millennIumAMbiguity
public class AIDeath : MonoBehaviour
{

    public Material mat;
    public SkinnedMeshRenderer smr;
    public AI ai;

    float level = 1f;

    static AIDeath instance;


    public void Die() {
        if (instance != null) {
            instance.ai.Kill();
        }
        instance = this;
        smr.material = mat;
        smr.material.SetFloat("_Level", 1);
        this.enabled = true;
    }


    void FixedUpdate() {
        smr.material.SetFloat("_Level", level);
        level -= Time.fixedDeltaTime;
        if (level <= 0) {
            instance = null;
            ai.Kill();
        }

    }
}
