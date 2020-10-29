using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponController : MonoBehaviour
{
    public int curWeapon = 2;
    public float scrollScale = 1f;
    public GameObject[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        if (weapons == null)
            Debug.LogWarning("No Weapons Found on Player.");
    }

    // Update is called once per frame
    void Update()
    {
        if (weapons != null)
            ChangeWeapons();

        if (Input.inputString != "")
        {
            int inputNumber;
            bool is_a_number = Int32.TryParse(Input.inputString, out inputNumber);
            if (is_a_number && inputNumber >= 0 && inputNumber < 10)
            {
                if (inputNumber - 1 <= weapons.Length)
                {
                    curWeapon = inputNumber - 1;
                }
            }
        }

        curWeapon += (int)Input.mouseScrollDelta.y * (int)scrollScale;
        curWeapon = Mathf.Clamp(curWeapon, 0, weapons.Length - 1);

    }

    void ChangeWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == curWeapon)
            {
                weapons[i].SetActive(true);
            }
            else
                weapons[i].SetActive(false);
        }
    }
}
