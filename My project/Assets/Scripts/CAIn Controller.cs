using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CAInController : MonoBehaviour
{

    public AudioClip[] CAInVoiceLinesLevel1;
    public AudioSource CAIn;

    private AudioClip currentClip;
    private XRNode rightHand = XRNode.RightHand;

    public void PlayIntroLine()
    {
        CAIn.Play();
    }
    public void PlayHintLevel1()
    {
        if(CAIn.isPlaying == false)
        {
            CAIn.PlayOneShot(CAInVoiceLinesLevel1[0]);
            currentClip = CAInVoiceLinesLevel1[0];
        }
    }

    public void PlayfinishLevel1NoHint()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel1[1]);
        currentClip = CAInVoiceLinesLevel1[1];
    }

    public void PlayfinishLevel1()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel1[2]);
        currentClip = CAInVoiceLinesLevel1[2];
    }

    public float GetCurrentAudioClipLength()
    {
        if (CAIn.clip != null)
        {
            return currentClip.length;
        }
        return 0f;
    }

    private void Update()
    {
        // Check if the "A" button is pressed on the right controller
        if (IsButtonPressed(rightHand, CommonUsages.primaryButton))
        {
            if (CAIn.isPlaying)
            {
                StopCurrentClip();
            }
        }
    }

    private bool IsButtonPressed(XRNode controller, InputFeatureUsage<bool> button)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controller);
        bool isPressed = false;
        if (device.TryGetFeatureValue(button, out isPressed) && isPressed)
        {
            return true;
        }
        return false;
    }

    public void StopCurrentClip()
    {
        if (CAIn.isPlaying)
        {
            CAIn.Stop();
            currentClip = null;
        }
    }
}
