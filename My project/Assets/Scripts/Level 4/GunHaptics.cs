using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunHaptics : MonoBehaviour
{
    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;
    [SerializeField] private float hapticDuration = 0.1f;
    [SerializeField] private float hapticAmplitude = 0.5f;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (leftController == null || rightController == null)
        {
            FindControllers();
        }
    }

    private void FindControllers()
    {
        XRBaseController[] controllers = FindObjectsOfType<XRBaseController>();

        foreach (XRBaseController controller in controllers)
        {
            if (controller.gameObject.name.ToLower().Contains("left"))
            {
                leftController = controller;
            }
            else if (controller.gameObject.name.ToLower().Contains("right"))
            {
                rightController = controller;
            }
        }
    }

    private void OnEnable()
    {
        grabInteractable.activated.AddListener(OnActivated);
    }

    private void OnDisable()
    {
        grabInteractable.activated.RemoveListener(OnActivated);
    }

    private void OnActivated(ActivateEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor interactor)
        {
            XRBaseController controller = interactor.xrController;
            if (controller != null)
            {
                controller.SendHapticImpulse(hapticAmplitude, hapticDuration);
            }
        }
    }
}
