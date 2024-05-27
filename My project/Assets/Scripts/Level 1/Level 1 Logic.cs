using System.Collections;
using UnityEngine;

public class Checkpuzzle1 : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSource, selectedSource;
    [SerializeField] private Transform PlayerTransform, Level2StartPosition, Level1StartPosition;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private CAInController cainController;
    public GameObject level2Logic;

    private bool dinosaurCheck = false, turttleCheck = false, bearCheck = false, reindeerCheck = false;
    private bool HintAsked = false;
    private void Start()
    {
        //uncomment
        //PlayerTransform.position = Level1StartPosition.position;
        //cainController.PlayIntroLine();
    } 
    private IEnumerator HandleMinigame1Completion()
    {
        // Play the appropriate audio track
        if (HintAsked)
        {
            cainController.PlayfinishLevel1();
        }
        else
        {
            cainController.PlayfinishLevel1NoHint();
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
        PlayerTransform.position = Level2StartPosition.position;

        //fade in
        yield return fadeController.FadeIn();

        //activate level 2 logic
        level2Logic.SetActive(true);
    }

    public void PuzzleCheck(int i)
    {
        switch (i)
        {
            case 0:
                turttleCheck = true;
                if (dinosaurCheck && bearCheck && reindeerCheck)
                {
                    StartCoroutine(HandleMinigame1Completion());
                }
                break;
            case 1:
                dinosaurCheck = true;
                if (turttleCheck && bearCheck && reindeerCheck)
                {
                    StartCoroutine(HandleMinigame1Completion());
                }
                break;
            case 2:
                bearCheck = true;
                if (turttleCheck && dinosaurCheck && reindeerCheck)
                {
                    StartCoroutine(HandleMinigame1Completion());
                }
                break;
            case 3:
                reindeerCheck = true;
                if (turttleCheck && dinosaurCheck && bearCheck)
                {
                    StartCoroutine(HandleMinigame1Completion());
                }
                break;
            default:
                break;
        }
    }

    public void HintCheck()
    {
        HintAsked = true;
    }

    public void HoverSound()
    {
        hoverSource.Play();
    }

    public void SelectedSound()
    {
        selectedSource.Play();
    }
}
