using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6Logic : MonoBehaviour
{
    public Cable[] correctOrder;
    private int currentCutIndex = 0;
    [SerializeField] private CAInController cainController;
    [SerializeField] private FadeController fadeController;
    [SerializeField] private AudioSource tickingAudioSource;
    [SerializeField] private AudioClip tickingClip;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip WinningMusic;
    [SerializeField] private AudioClip TensionMusic;
    [SerializeField] private BoxCollider playerCollider;
    [SerializeField] private AudioSource AmbientEmitter;
    private bool timerStarted = false;
    private float countdownDuration = 60f; 
    private float maxPitch = 2f; 

    private void Start()
    {
        AmbientEmitter.Stop();
        cainController.PlayIntroLevel6();
        musicSource.PlayOneShot(WinningMusic);
    }

    public void CableCut(Cable cutCable)
    {
        if (correctOrder[currentCutIndex] == cutCable)
        {
            Debug.Log("Cable cut");
            currentCutIndex++;
            if (currentCutIndex >= correctOrder.Length)
            {
                Debug.Log("Game finished");
                cainController.PlayfinishLevel6();
                StopTickingSound();
                StopAllCoroutines();
            }
        }
        else
        {
            Explode();
        }
    }

    private IEnumerator TeleportPlayer()
    {
        yield return fadeController.FadeOut();
        SceneManager.LoadScene("BasicScene");
        yield return fadeController.FadeIn();
    }

    private void Explode()
    {
        Debug.Log("Bomb exploded!");
        StartCoroutine(TeleportPlayer());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("xddd");
        if (!timerStarted)
        {
            musicSource.Stop();
            Debug.Log("Tic started");
            timerStarted = true;
            StartCoroutine(StartTimer());
            PlayTickingSound();
            cainController.PlaySurpriseLevel6();
            musicSource.PlayOneShot(TensionMusic);

        }
    }

    private IEnumerator StartTimer()
    {
        float elapsedTime = 0f;
        while (elapsedTime < countdownDuration)
        {
            elapsedTime += Time.deltaTime;
            AdjustTickingPitch(elapsedTime / countdownDuration);
            yield return null;
        }
        Explode();
    }

    private void PlayTickingSound()
    {
        if (tickingAudioSource != null && tickingClip != null)
        {
            tickingAudioSource.clip = tickingClip;
            tickingAudioSource.loop = true;
            tickingAudioSource.Play();
        }
    }

    private void StopTickingSound()
    {
        if (tickingAudioSource != null)
        {
            tickingAudioSource.Stop();
        }
    }

    private void AdjustTickingPitch(float progress)
    {
        if (tickingAudioSource != null)
        {
            tickingAudioSource.pitch = Mathf.Lerp(1f, maxPitch, progress);
        }
    }
}
