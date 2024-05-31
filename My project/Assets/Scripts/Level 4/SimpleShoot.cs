using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location References")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destroy the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;
    [Tooltip("Cooldown between shots in seconds")] [SerializeField] private float shotCooldown = 0.5f;

    public AudioSource source;
    public AudioClip fireSound;
    public AudioClip reload;
    public AudioClip noammo;
    public Magazine magazine;
    public XRSocketInteractor socketInteractor;

    private bool canShoot = true;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        socketInteractor.selectEntered.AddListener(AddMagazine);
        socketInteractor.selectExited.AddListener(RemoveMagazine);
    }

    public void AddMagazine(SelectEnterEventArgs args)
    {
        if (args.interactable is XRBaseInteractable interactable)
        {
            magazine = interactable.GetComponent<Magazine>();
            source.PlayOneShot(reload);
        }
    }

    public void RemoveMagazine(SelectExitEventArgs args)
    {
        magazine = null;
        source.PlayOneShot(reload);
    }

    public void PullTheTrigger()
    {
        if (canShoot && magazine != null && magazine.bulletCount > 0)
        {
            StartCoroutine(ShootCoroutine());
        }
        else if (magazine == null || magazine.bulletCount == 0)
        {
            source.PlayOneShot(noammo);
            Debug.Log("Out of bullets! Reload!");
        }
    }

    private IEnumerator ShootCoroutine()
    {
        canShoot = false;

        // Disparar una bala
        Shoot();
        magazine.bulletCount--;

        // Reproducir sonido y activar animación
        source.PlayOneShot(fireSound);
        gunAnimator.SetTrigger("ShootTrigger");

        // Esperar a que la animación termine antes de permitir otro disparo
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }

    //This function creates the bullet behavior
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //Cancels if there's no bullet prefab
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower),
            (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f),
            Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }
}