using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CAInController : MonoBehaviour
{

    public AudioClip[] CAInVoiceLinesLevel1;
    public AudioClip[] CAInVoiceLinesLevel2;
    public AudioClip[] CAInVoiceLinesLevel3;
    public AudioSource CAIn;

    private AudioClip currentClip;
    private XRNode rightHand = XRNode.RightHand;

    //=========================LEVEL 1=========================
    public void PlayIntroLine()
    {
        CAIn.Play();
    }
    public void PlayHintLevel1()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel1[0]);
        currentClip = CAInVoiceLinesLevel1[0];
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

    //=========================LEVEL 2=========================

    public void PlayIntroLevel2()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[0]);
    }
    public void PlayHintLevel2()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[1]);
        currentClip = CAInVoiceLinesLevel2[1];
    }

    public void PlayfinishLevel2NoHint()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[2]);
        currentClip = CAInVoiceLinesLevel2[2];
    }

    public void PlayfinishLevel2()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[3]);
        currentClip = CAInVoiceLinesLevel2[3];
    }

    //=========================LEVEL 3=========================

    public void PlayIntroLevel3()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[0]);
    }
    public void PlayHintLevel3()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[1]);
        currentClip = CAInVoiceLinesLevel3[1];
    }

    public void PlayfinishLevel3NoHint()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[2]);
        currentClip = CAInVoiceLinesLevel3[2];
    }

    public void PlayfinishLevel3()
    {
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[3]);
        currentClip = CAInVoiceLinesLevel3[3];
    }

    //stop voicelines
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

    //utils
    public float GetCurrentAudioClipLength()
    {
        if (CAIn.clip != null)
        {
            return currentClip.length;
        }
        return 0f;
    }
}
