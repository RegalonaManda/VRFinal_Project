using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CAInController : MonoBehaviour
{

    public AudioClip[] CAInVoiceLinesLevel1;
    public AudioClip[] CAInVoiceLinesLevel2;
    public AudioClip[] CAInVoiceLinesLevel3;
    public AudioClip[] CAInVoiceLinesLevel4;
    public AudioClip[] CAInVoiceLinesLevel5;
    public AudioClip[] CAInVoiceLinesLevel6;
    public AudioSource CAIn;

    private AudioClip currentClip;
    private XRNode rightHand = XRNode.RightHand;

    //=========================LEVEL 1=========================
    public void PlayIntroLine()
    {
        CAIn.Stop();
        CAIn.Play();
    }
    public void PlayHintLevel1()
    {
        if(currentClip == CAInVoiceLinesLevel1[1] || currentClip == CAInVoiceLinesLevel1[2] || currentClip == CAInVoiceLinesLevel1[3])
        {
            return;
        }
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel1[0]);
        currentClip = CAInVoiceLinesLevel1[0];
    }

    public void PlayfinishLevel1NoHint()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel1[1]);
        currentClip = CAInVoiceLinesLevel1[1];
    }

    public void PlayfinishLevel1()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel1[2]);
        currentClip = CAInVoiceLinesLevel1[2];
    }

    public void PlayfinishLevel1Wrong()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel1[3]);
        currentClip = CAInVoiceLinesLevel1[3];
    }

    //=========================LEVEL 2=========================

    public void PlayIntroLevel2()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[0]);
    }
    public void PlayHintLevel2()
    {
        if (currentClip == CAInVoiceLinesLevel2[2] || currentClip == CAInVoiceLinesLevel2[3])
        {
            return;
        }
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[1]);
        currentClip = CAInVoiceLinesLevel2[1];
    }

    public void PlayfinishLevel2NoHint()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[2]);
        currentClip = CAInVoiceLinesLevel2[2];
    }

    public void PlayfinishLevel2()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel2[3]);
        currentClip = CAInVoiceLinesLevel2[3];
    }

    //=========================LEVEL 3=========================

    public void PlayIntroLevel3()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[0]);
    }
    public void PlayHintLevel3()
    {
        if (currentClip == CAInVoiceLinesLevel3[2] || currentClip == CAInVoiceLinesLevel3[3])
        {
            return;
        }
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[1]);
        currentClip = CAInVoiceLinesLevel3[1];
    }

    public void PlayfinishLevel3NoHint()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[2]);
        currentClip = CAInVoiceLinesLevel3[2];
    }

    public void PlayfinishLevel3()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel3[3]);
        currentClip = CAInVoiceLinesLevel3[3];
    }

    //=========================LEVEL 4=========================

    public void PlayIntroLevel4()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel4[0]);
    }
    public void PlayHintLevel4()
    {
        if (currentClip == CAInVoiceLinesLevel4[2] || currentClip == CAInVoiceLinesLevel4[3])
        {
            return;
        }
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel4[1]);
        currentClip = CAInVoiceLinesLevel4[1];
    }

    public void PlayfinishLevel4NoHint()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel4[2]);
        currentClip = CAInVoiceLinesLevel4[2];
    }

    public void PlayfinishLevel4()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel4[3]);
        currentClip = CAInVoiceLinesLevel4[3];
    }

    //=========================LEVEL 5=========================

    public void PlayIntroLevel5()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel5[0]);
    }
    public void PlayHintLevel5()
    {
        if (currentClip == CAInVoiceLinesLevel5[2] || currentClip == CAInVoiceLinesLevel5[3])
        {
            return;
        }
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel5[1]);
        currentClip = CAInVoiceLinesLevel5[1];
    }

    public void PlayfinishLevel5NoHint()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel5[2]);
        currentClip = CAInVoiceLinesLevel5[2];
    }

    public void PlayfinishLevel5()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel5[3]);
        currentClip = CAInVoiceLinesLevel5[3];
    }

    //=========================FINAL LEVEL=========================

    public void PlayIntroLevel6()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel6[0]);
        currentClip = CAInVoiceLinesLevel6[0];
    }

    public void PlaySurpriseLevel6()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel6[1]);
        currentClip = CAInVoiceLinesLevel6[1];
    }
    public void PlayfinishLevel6()
    {
        CAIn.Stop();
        CAIn.PlayOneShot(CAInVoiceLinesLevel6[2]);
        currentClip = CAInVoiceLinesLevel6[2];
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
