using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Logic : MonoBehaviour
{
    [SerializeField] private CAInController cainController;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private Transform PlayerTransform, Level6StartPosition;
    public GameObject level6Logic;
    private bool HintAsked = false;
    private bool finishedMinigame = false;
    public bool FinishedMinigame
    {
        get { return finishedMinigame; }
        set { finishedMinigame = value; }
    }
    private void Start()
    {
        cainController.PlayIntroLevel5();
    }
    public void Minigame5Finished()
    {
        Debug.Log("mingame 5 finished");
        if(!finishedMinigame)
        {
            FinishedMinigame = true;
            StartCoroutine(HandleMinigame5Completion());
        }
    }

    private IEnumerator HandleMinigame5Completion()
    {
        // Play the appropriate audio track
        if (HintAsked)
        {

            cainController.PlayfinishLevel5();
        }
        else
        {

            cainController.PlayfinishLevel5NoHint();
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
        PlayerTransform.position = Level6StartPosition.position;

        //fade in
        yield return fadeController.FadeIn();

        //activate level 4 logic
        level6Logic.SetActive(true);
    }
    public void HintCheck()
    {
        HintAsked = true;
    }
}
