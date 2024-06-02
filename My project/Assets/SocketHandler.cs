using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketInteractionHandler : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public string nameTargetObject;
    public Level1Logic level1Logic;
    public bool full = false;
    public bool Check = false;

    void Start()
    {
        socketInteractor.selectEntered.AddListener(OnObjectEntered);
        socketInteractor.selectExited.AddListener(OnObjectExited);
    }

    void OnObjectEntered(SelectEnterEventArgs args)
    {
        GameObject enteredObject = args.interactableObject.transform.gameObject;
        Debug.Log("Object entered: " + enteredObject.name);

        HandleObjectEntered(enteredObject);
    }

    void OnObjectExited(SelectExitEventArgs args)
    {
        GameObject exitedObject = args.interactableObject.transform.gameObject;
        Debug.Log("Object exited: " + exitedObject.name);

        HandleObjectExited(exitedObject);
    }

    void HandleObjectEntered(GameObject obj)
    {
        full = true;
        Debug.Log(obj.name + " full true");
        if (obj.name == nameTargetObject)
        {
            Debug.Log(obj.name + " check true");
            Check = true;
        }
        else
        {
            Check = false; // Make sure to reset Check if the object doesn't match
            Debug.Log(obj.name + " full true check false");
        }

        level1Logic.PuzzleCheck();
    }

    void HandleObjectExited(GameObject obj)
    {
        full = false;
        Check = false;
    }
}
