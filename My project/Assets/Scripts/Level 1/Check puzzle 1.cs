using System.Collections;
using UnityEngine;

public class Checkpuzzle1 : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSource, selectedSource;
    [SerializeField] private Transform PlayerTransform, Level2StartPosition;
    [SerializeField] private FadeController fadeController;

    private bool dinosaurCheck = false, turttleCheck = false, bearCheck = false, reindeerCheck = false;
    private bool minigameCompleted = false;

    void Update()
    {
        if (minigameCompleted)
        {
            StartCoroutine(TeleportPlayer());
            minigameCompleted = false; // avoid multiple calls
        }
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
                    minigameCompleted = true;
                }
                break;
            case 1:
                dinosaurCheck = true;
                if (turttleCheck && bearCheck && reindeerCheck)
                {
                    minigameCompleted = true;
                }
                break;
            case 2:
                bearCheck = true;
                if (turttleCheck && dinosaurCheck && reindeerCheck)
                {
                    minigameCompleted = true;
                }
                break;
            case 3:
                reindeerCheck = true;
                if (turttleCheck && dinosaurCheck && bearCheck)
                {
                    minigameCompleted = true;
                }
                break;
            default:
                break;
        }
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
