using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetButtonDown("cancel")) {
            Back();
        }
    }

    public void Back() {
        AutoFade.LoadLevel(0, 2f, 1f, Color.black);
    }
}
