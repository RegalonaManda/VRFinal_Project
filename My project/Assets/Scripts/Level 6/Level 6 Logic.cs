using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6Logic : MonoBehaviour
{
    public Cable[] correctOrder;
    private int currentCutIndex = 0;

    //tp al nivel de victoria
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Transform WinLevelTransform; 
    //controllers
    [SerializeField] private CAInController cainController;
    [SerializeField] private FadeController fadeController;
    //ticking
    [SerializeField] private AudioSource tickingAudioSource;
    [SerializeField] private AudioClip tickingClip;
    //musics
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip WinningMusic;
    [SerializeField] private AudioClip TensionMusic;
    //explosion sfx + camera shake
    [SerializeField] private AudioClip Explosion;
    [SerializeField] private CameraShake cameraShake;
    //player
    [SerializeField] private BoxCollider playerCollider;
    //ambient emitter
    [SerializeField] private AudioSource AmbientEmitter;
    //logic variables
    private bool timerStarted = false;
    private float countdownDuration = 60f; 
    private float maxPitch = 2f;
    [SerializeField] private AudioClip Spark;


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
            currentCutIndex++;
            musicSource.PlayOneShot(Spark);
            if (currentCutIndex >= correctOrder.Length)
            {
                cainController.PlayfinishLevel6();
                StopTickingSound();
                StopAllCoroutines();
                StartCoroutine(TeleportPlayerWin());
                musicSource.Stop();
              
            }
        }
        else
        {
            Explode();
        }
    }

    
    private IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(1f);
        yield return fadeController.FadeOut();
        SceneManager.LoadScene("BasicScene");
        yield return fadeController.FadeIn();
    }
    private IEnumerator TeleportPlayerWin()
    {
        yield return new WaitForSeconds(cainController.GetCurrentAudioClipLength());
        // Fade out
        yield return fadeController.FadeOut();

        // TP player
        PlayerTransform.position = WinLevelTransform.position;

        // Fade in
        yield return fadeController.FadeIn();
     
        StopAllCoroutines();
    }
    private void Explode()
    {
        tickingAudioSource.Stop();
        cameraShake.StartShake();
        tickingAudioSource.PlayOneShot(Explosion);
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
