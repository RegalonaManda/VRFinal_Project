using UnityEngine;
using System.Collections;

public class SequentialAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] Songs;
    [SerializeField] private AudioSource audioSource;

    private int currentIndex = 0;  // Índice actual en el array

    void Start()
    {
        if (Songs == null || Songs.Length == 0)
        {
            Debug.LogError("No audio sources assigned!");
            return;
        }

        // Comienza la reproducción secuencial
        StartCoroutine(PlaySequentially());
    }

    IEnumerator PlaySequentially()
    {
        while (true)
        {
            if (Songs[currentIndex] != null)
            {
                audioSource.PlayOneShot(Songs[currentIndex]);
                yield return new WaitForSeconds(audioSource.clip.length);
            }

            // Avanza al siguiente AudioSource, reiniciando si es necesario
            currentIndex = (currentIndex + 1) % Songs.Length;
        }
    }
}
