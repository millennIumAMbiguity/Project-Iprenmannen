using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//Johan B.
public class GunBase : WeaponBase
{
    [Header("Components")]
    public Slider overHeatSlider;
    public Image sliderFill;
    public ParticleSystem shootEffect;

    [Header("Gun Settings")]
    [Tooltip("Time between shots")]
    public float cooldownTimer = 0.25f;
    public bool automatic = false;
    [Header("Overheating stats")]
    public float maxOverheat = 100;
    [SerializeField]
    private float curOverheat = 0;
    public float fastOverheatCooldownTimer = 3f;
    public float overheatPerShot = 15f;
    public float normalOverheatDecreaseValue = 15f;
    public float fastOverheatDecreaseValue = 25f;

    public bool overChargeReached = false;
    public float overChargeReachedDiff = 0.5f;
    private bool canShoot = true;
    [SerializeField]
    private bool fastOverHeatCooldown = true;

#if UNITY_EDITOR
    private void Start()
    {
        if (overHeatSlider == null || sliderFill == null)
            Debug.LogWarning("Slider/SliderFill not found.");
        shootEffect = GetComponentInChildren<ParticleSystem>();
    }
#endif

    void Update()
    {
        curOverheat = Mathf.Clamp(curOverheat, 0, maxOverheat);

        if (overHeatSlider && sliderFill != null)
            OverheatManagement();

        if (!automatic)
        {
            if (Input.GetButtonDown("Fire1") && canShoot)
            {
                if (shootEffect != null)
                    shootEffect.Play();

                StopCoroutine(FastOverchargeCooldown());
                RaycastHit();
                if (overHeatSlider != null)
                    curOverheat += overheatPerShot;

                StartCoroutine(ShootCooldown());
                StartCoroutine(FastOverchargeCooldown());
            }
        }
        else if (automatic)
        {
            if (Input.GetButton("Fire1") && canShoot)
            {
                if (shootEffect != null)
                    shootEffect.Play();

                StopCoroutine(FastOverchargeCooldown());
                RaycastHit();
                if (overHeatSlider != null)
                    curOverheat += overheatPerShot;

                StartCoroutine(ShootCooldown());
                StartCoroutine(FastOverchargeCooldown());
            }
        }
    }

    private void OverheatManagement()
    {
        overHeatSlider.value = curOverheat;

        if (curOverheat > 0)
        {
            curOverheat -= fastOverHeatCooldown ?
                fastOverheatDecreaseValue * Time.deltaTime : normalOverheatDecreaseValue * Time.deltaTime;
        }

        if (curOverheat >= maxOverheat - overChargeReachedDiff)
            overChargeReached = true;

        if (overChargeReached && canShoot)
        {
            canShoot = false;
            StopAllCoroutines();
            StartCoroutine(FastOverchargeCooldown());
        }
        else if (overChargeReached && curOverheat <= 0 + overChargeReachedDiff)
        {
            overChargeReached = false;
            canShoot = true;
        }
        else if (curOverheat <= 0 + overChargeReachedDiff)
        {
            overChargeReached = false;
            canShoot = true;
        }


        sliderFill.color = Color.Lerp(Color.white, Color.red, curOverheat / maxOverheat);
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
