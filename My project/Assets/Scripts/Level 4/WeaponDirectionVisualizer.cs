using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponDirectionVisualizer : MonoBehaviour
{
    public GameObject visualCube; // Asigna el cubo visual en el Inspector
    public XRGrabInteractable grabInteractable; // Asigna el XRGrabInteractable en el Inspector

    private Transform muzzleTransform; // Referencia al transform de la punta del arma
    private GameObject instantiatedCube; // Referencia al cubo visual instanciado

    [System.Obsolete]
    void Start()
    {
        muzzleTransform = transform.Find("LaserStart"); // Ajusta el nombre seg�n el transform de la punta del arma

        if (visualCube)
        {
            visualCube.SetActive(false); // Aseg�rate de que el cubo visual est� desactivado al inicio
        }

        // Suscribe a los eventos de entrada y salida del XRGrabInteractable
        if (grabInteractable)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrab);
            grabInteractable.onSelectExited.AddListener(OnRelease);
        }
    }

    // M�todo para activar el cubo visual cuando se agarra el arma
    // M�todo para activar el cubo visual cuando se agarra el objeto
    private void OnGrab(XRBaseInteractor interactor)
    {
        if (visualCube)
        {
            visualCube.SetActive(true);
        }
    }

    // M�todo para desactivar el cubo visual cuando se suelta el objeto
    private void OnRelease(XRBaseInteractor interactor)
    {
        if (visualCube)
        {
            visualCube.SetActive(false);
        }
    }
}

