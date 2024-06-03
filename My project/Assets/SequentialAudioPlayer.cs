using UnityEngine;
using System.Collections;

public class SequentialAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] Songs;
    [SerializeField] private AudioSource audioSource;

    private int currentIndex = 0;  // �ndice actual en el array

    void Start()
    {
        if (Songs == null || Songs.Length == 0)
        {
            Debug.LogError("No audio clips assigned!");
            return;
        }

        // Comienza la reproducci�n secuencial
        StartCoroutine(PlaySequentially());
    }

    IEnumerator PlaySequentially()
    {
        while (true)
        {
            if (Songs[currentIndex] != null)
            {
                audioSource.clip = Songs[currentIndex];
                audioSource.Play();

                // Espera la duraci�n del clip
                yield return new WaitForSeconds(audioSource.clip.length);

                // Espera hasta que el clip termine de reproducirse, en caso de que haya pausas o desincronizaci�n
                while (audioSource.isPlaying)
                {
                    yield return null;
                }
            }

            // Avanza al siguiente AudioSource, reiniciando si es necesario
            currentIndex = (currentIndex + 1) % Songs.Length;
        }
    }
}
