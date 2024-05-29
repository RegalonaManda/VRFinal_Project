using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level3Logic : MonoBehaviour
{
    [SerializeField] private MovingTarget[] targets;
    [SerializeField] private CAInController cainController;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private Transform PlayerTransform, Level4StartPosition;
    public GameObject level4Logic;
    private bool finishedMinigame = false;
    private bool HintAsked = false;

    void Start()
    {
        cainController.PlayIntroLevel3();
    }
    public void CheckRemainingTargets()
    {

        // Check if all targets are stopped
        if (targets.All(target => target.stopped && !finishedMinigame))
        {
            StartCoroutine(HandleMinigame3Completion());
            finishedMinigame = true;
        }
    }

    private IEnumerator HandleMinigame3Completion()
    {
        // Play the appropriate audio track
        if (HintAsked)
        {

            cainController.PlayfinishLevel3();
        }
        else
        {

            cainController.PlayfinishLevel3NoHint();
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
        PlayerTransform.position = Level4StartPosition.position;

        //fade in
        yield return fadeController.FadeIn();

        //activate level 4 logic
        level4Logic.SetActive(true);
    }

    

    public void HintCheck()
    {
        HintAsked = true;
    }
}
