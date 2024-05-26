using System.Collections;
using UnityEngine;

public class Checkpuzzle1 : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSource, selectedSource;
    [SerializeField] private Transform PlayerTransform, Level2StartPosition, Level1StartPosition;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private CAInController cainController;

    private bool dinosaurCheck = false, turttleCheck = false, bearCheck = false, reindeerCheck = false;
    private bool HintAsked = false;
    private void Start()
    {
        PlayerTransform.position = Level1StartPosition.position;
        cainController.PlayIntroLine();
    }

    private void MinigameCompleted()
    {
        StartCoroutine(HandleMinigameCompletion());
    }

    private IEnumerator HandleMinigameCompletion()
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

    void WaitAudioFinish()
    {

    }

    private IEnumerator TeleportPlayer()
    {
        //fade out
        yield return fadeController.FadeOut();

        // Tp player
        PlayerTransform.position = Level2StartPosition.position;

        //fade in
        yield return fadeController.FadeIn();
    }

    public void PuzzleCheck(int i)
    {
        switch (i)
        {
            case 0:
                turttleCheck = true;
                if (dinosaurCheck && bearCheck && reindeerCheck)
                {
                    MinigameCompleted();
                }
                break;
            case 1:
                dinosaurCheck = true;
                if (turttleCheck && bearCheck && reindeerCheck)
                {
                    MinigameCompleted();
                }
                break;
            case 2:
                bearCheck = true;
                if (turttleCheck && dinosaurCheck && reindeerCheck)
                {
                    MinigameCompleted();
                }
                break;
            case 3:
                reindeerCheck = true;
                if (turttleCheck && dinosaurCheck && bearCheck)
                {
                    MinigameCompleted();
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
