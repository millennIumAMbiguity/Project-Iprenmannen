using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScroll : MonoBehaviour
{

    public RectTransform trans;
    public float speed = 10;

    void Update()
    {
        trans.position -= new Vector3(0,-Time.deltaTime * speed, 0);
    }
}
