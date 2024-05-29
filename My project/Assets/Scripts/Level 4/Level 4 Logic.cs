using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Logic : MonoBehaviour
{
    private int targetsShot = 0;
    [SerializeField] private int numberOfTargets;
    [SerializeField] private CAInController cainController;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private Transform PlayerTransform, Level5StartPosition;
    public GameObject level5Logic;
    private bool finishedMinigame = false;
    private bool HintAsked = false;

    public bool FinishedMinigame
    {
        get { return finishedMinigame; }
        set { finishedMinigame = value; }
    }
    public int TargetsShot
    {
        get { return targetsShot; }
        set { targetsShot = value; }
    }
    void Start()
    {
        cainController.PlayIntroLevel4();
    }

    public void CheckRemainingTargets()
    {
        Debug.Log("targets shot:");
        Debug.Log(targetsShot);
        // Check if the necesary number of targets are shot
        if (numberOfTargets == targetsShot && !finishedMinigame)
        {
            StartCoroutine(HandleMinigame4Completion());
            finishedMinigame = true;
        }
    }

    private IEnumerator HandleMinigame4Completion()
    {
        // Play the appropriate audio track
        if (HintAsked)
        {

            cainController.PlayfinishLevel4();
        }
        else
        {

            cainController.PlayfinishLevel4NoHint();
        }

        // Wait for the audio to finish
        yield return new WaitForSeconds(cainController.GetCurrentAudioClipLength());
        // Start the teleport coroutine
        yield return StartCoroutine(TeleportPlayer());
    }

    private IEnumerator TeleportPlayer()
    {
        //fade out
        yield return fadeController.FadeOut();

        // Tp player
        PlayerTransform.position = Level5StartPosition.position;

        //fade in
        yield return fadeController.FadeIn();

        //activate level 4 logic
        level5Logic.SetActive(true);
    }
    public void HintCheck()
    {
        HintAsked = true;
    }
}
