using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


    public AudioSource source;
    public AudioClip fireSound;
    public AudioClip reload;
    public Magazine magazine;
    public XRBaseInteractable socketInteractor;

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
        if (args.interactable is XRBaseInteractable interactable)
        {
            magazine = null;
            source.PlayOneShot(reload);
        }
    }

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        socketInteractor.selectEntered.AddListener(AddMagazine);
        socketInteractor.selectExited.AddListener(RemoveMagazine);
    }

   
    private void RemoveMagazine(SelectExitEventArgs arg0, XRBaseInteractable interactable)
    {
        throw new System.NotImplementedException();
    }

    private void AddMagazine(SelectEnterEventArgs arg0, XRBaseInteractable interactable)
    {
        throw new System.NotImplementedException();
        magazine = interactable.GetComponent<Magazine>();
        source.PlayOneShot(reload);
    }

    public void PullTheTrigger()
    {
      
        // Si la animación está actualmente en curso, interrumpirla y reiniciarla
        if (gunAnimator.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
        {
            // Reiniciar la animación de disparo
            source.Play();
            gunAnimator.Play("Fire", 0, 0f); // Rebobina la animación al inicio
        }
        else
        {
            // Iniciar la animación de disparo
            source.Play();
            gunAnimator.SetTrigger("ShootTrigger");

        }
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

        //cancels if there's no bullet prefeb
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
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}