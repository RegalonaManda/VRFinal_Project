using System.Collections;
using UnityEngine;

public class Level1Logic : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSource, selectedSource;
    [SerializeField] private Transform PlayerTransform, Level2StartPosition, Level1StartPosition;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private CAInController cainController;
    [SerializeField] private SocketInteractionHandler[] Figures;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private Transform attachPoint1, attachPoint2;
    public GameObject level2Logic;

    private bool HintAsked = false;
    private bool finishedwrong = false;

    private void Start()
    {
        PlayerTransform.position = Level1StartPosition.position;
        cainController.PlayIntroLine();
    }

    private IEnumerator HandleMinigame1Completion()
    {
        // Play the appropriate audio track and trigger particles
        if (HintAsked && !finishedwrong)
        {
            cainController.PlayfinishLevel1();
            TriggerParticles();
        }
        else if (finishedwrong)
        {
            cainController.PlayfinishLevel1Wrong();
            TriggerParticles();
        }
        else
        {
            cainController.PlayfinishLevel1NoHint();
            TriggerParticles();
        }

        // Wait for the audio to finish
        yield return new WaitForSeconds(cainController.GetCurrentAudioClipLength());
        // Start the teleport coroutine
        yield return StartCoroutine(TeleportPlayer());
    }

    private IEnumerator TeleportPlayer()
    {
        // Fade out
        yield return fadeController.FadeOut();

        // TP player
        PlayerTransform.position = Level2StartPosition.position;

        // Fade in
        yield return fadeController.FadeIn();

        // Activate level 2 logic
        level2Logic.SetActive(true);
    }

    public void PuzzleCheck()
    {
        for (int i = 0; i < Figures.Length; ++i)
        {
            if (Figures[i].full)
            {
                Debug.Log(Figures[i].name + " is full");
            }
            else
            {
                Debug.Log(Figures[i].name + " is not full");
                return;
            }
        }

        Debug.Log("All figures are full");

        for (int i = 0; i < Figures.Length; ++i)
        {
            if (Figures[i].Check)
            {
                Debug.Log(Figures[i].name + " is checked");
            }
            else
            {
                Debug.Log(Figures[i].name + " is not checked");
                finishedwrong = true;
                break;
            }
        }

        Debug.Log("All figures are checked");
        StartCoroutine(HandleMinigame1Completion());
    }

    private void TriggerParticles()
    {
        // Instanciar y reproducir partículas en los puntos de attach
        if (particlePrefab != null && attachPoint1 != null && attachPoint2 != null)
        {
            Instantiate(particlePrefab, attachPoint1.position, attachPoint1.rotation);
            Instantiate(particlePrefab, attachPoint2.position, attachPoint2.rotation);
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
