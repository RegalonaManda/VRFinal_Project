using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Level2Logic : MonoBehaviour
{
    public List<Level2Button> buttons;
    public List<int> correctSequence;
    [SerializeField] private CAInController cainController;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private Transform PlayerTransform, Level3StartPosition;
    public GameObject level3Logic;

    private int currentStep;
    private bool HintAsked = false;

    private void Start()
    {
        cainController.PlayIntroLevel2();
        ResetGame();
    }

    public bool CheckButtonPress(int buttonIndex)
    {
        if (buttonIndex == correctSequence[currentStep])
        {
            currentStep++;
            if (currentStep >= correctSequence.Count)
            {
                // Minigame completed
                Debug.Log("Minigame completed!");
                StartCoroutine(HandleMinigame2Completion());
                return true;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator HandleMinigame2Completion()
    {
        // Play the appropriate audio track
        if (HintAsked)
        {
            cainController.PlayfinishLevel2();
        }
        else
        {
            cainController.PlayfinishLevel2NoHint();
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
        PlayerTransform.position = Level3StartPosition.position;

        //fade in
        yield return fadeController.FadeIn();

        //activate level 3 logic
        level3Logic.SetActive(true);
    }


    public void ResetButtons()
    {
        foreach (var button in buttons)
        {
            button.ResetPosition();
        }
        currentStep = 0;
    }

    public void ResetGame()
    {
        currentStep = 0;
        foreach (var button in buttons)
        {
            button.ResetPosition();
        }
    }

    public void HintCheck()
    {
        HintAsked = true;
    }
}
