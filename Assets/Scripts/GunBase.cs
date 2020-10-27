using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Johan B.
public class GunBase : WeaponBase
{
    [Header("Components")]
    public Slider overHeatSlider;
    public Image sliderFill;

    [Header("Gun Settings")]
    [Tooltip("Time between shots")]
    public float cooldownTimer = 0.25f;
    public bool automatic = false;
    [Header("Overheating stats")]
    public float fastOverheatCooldownTimer = 3f;
    public float overheatPerShot = 15f;
    public float normalOverheatDecreaseValue = 15f;
    public float fastOverheatDecreaseValue = 25f;

    public bool overChargeReached = false;
    public float overChargeReachedDiff = 0.5f;
    private bool canShoot = true;
    [SerializeField]
    private bool fastOverHeatCooldown = true;

    private void Start()
    {
        if (overHeatSlider == null || sliderFill == null)
            Debug.Log("<color=red>Error: </color>Slider/SliderFill not found.");
    }

    void Update()
    {

        if (overHeatSlider && sliderFill != null)
            OverheatManagement();

        if (!automatic)
        {
            if (Input.GetButtonDown("Fire1") && canShoot)
            {
                StopCoroutine(FastOverchargeCooldown());
                RaycastHit();
                if (overHeatSlider != null)
                    overHeatSlider.value += overheatPerShot;

                StartCoroutine(ShootCooldown());
                StartCoroutine(FastOverchargeCooldown());
            }
        }
        else if (automatic)
        {
            if (Input.GetButton("Fire1") && canShoot)
            {
                StopCoroutine(FastOverchargeCooldown());
                RaycastHit();
                if (overHeatSlider != null)
                    overHeatSlider.value += overheatPerShot;

                StartCoroutine(ShootCooldown());
                StartCoroutine(FastOverchargeCooldown());
            }
        }
    }

    private void OverheatManagement()
    {
        if (overHeatSlider.value > 0)
        {
            overHeatSlider.value -= fastOverHeatCooldown ?
                fastOverheatDecreaseValue * Time.deltaTime : normalOverheatDecreaseValue * Time.deltaTime;
        }

        if (overHeatSlider.value >= overHeatSlider.maxValue - overChargeReachedDiff)
            overChargeReached = true;

        if (overChargeReached && canShoot)
        {
            canShoot = false;
            StopAllCoroutines();
            StartCoroutine(FastOverchargeCooldown());
        }
        else if (overChargeReached && overHeatSlider.value <= 0 + overChargeReachedDiff)
        {
            overChargeReached = false;
            canShoot = true;
        }

        sliderFill.color = Color.Lerp(Color.white, Color.red, overHeatSlider.value / overHeatSlider.maxValue);
    }

    IEnumerator FastOverchargeCooldown()
    {
        fastOverHeatCooldown = false;
        yield return new WaitForSeconds(fastOverheatCooldownTimer);
        fastOverHeatCooldown = true;
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTimer);
        canShoot = true;
    }
}
