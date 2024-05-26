using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Level2Button : MonoBehaviour
{
    public int buttonIndex;
    public Transform pushablePart;
    public Level2Logic gameController;
    private Vector3 vector = new Vector3(0, 0.04f, 0);
    private bool buttonPushed;

    private void Start()
    {
    }

    private void Update()
    {
        if (buttonPushed)
        {
            pushablePart.localPosition = Vector3.zero;
        }
        else
        {
            pushablePart.localPosition = vector;
        }
    }

    public void OnButtonPressed()
    {
        if (gameController.CheckButtonPress(buttonIndex))
        {
            buttonPushed = true;
        }
        else
        {
            gameController.ResetButtons();
        }
    }

    public void ResetPosition()
    {
        if (pushablePart != null)
        {
            pushablePart.localPosition = vector;
            buttonPushed = false;
        }
    }
}
