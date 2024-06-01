using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public int damageAmount = 10;

    // Referencias a los clips de sonido
    public AudioClip CristalRoto;
    public GameObject dianaPrefab;
    private Level4Logic level4logic;

    // Rango de valores para el pitch y el volumen
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;
    public float minVolume = 0.8f;
    public float maxVolume = 1.0f;

    private void Start()
    {
        level4logic = FindObjectOfType<Level4Logic>();
        if (level4logic == null)
        {
            Debug.LogError("No se encontró Level4Logic en la escena.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Diana"))
        {
            // Guardar la velocidad y rotación angular del objeto original
            Rigidbody originalRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 originalVelocity = Vector3.zero;
            Vector3 originalAngularVelocity = Vector3.zero;

            if (originalRb != null)
            {
                originalVelocity = originalRb.velocity;
                originalAngularVelocity = originalRb.angularVelocity;
            }

            // Instanciar el nuevo prefab en la misma posición y rotación que el objeto original
            GameObject newDiana = Instantiate(dianaPrefab, collision.transform.position, collision.transform.rotation);

            // Aplicar la misma velocidad y rotación angular a todos los rigidbodies en el nuevo prefab
            Rigidbody[] newRbs = newDiana.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody newRb in newRbs)
            {
                newRb.velocity = originalVelocity;
                newRb.angularVelocity = originalAngularVelocity;
            }

            // Reproducir el sonido usando un objeto temporal y destruir los objetos
            PlaySoundAtPosition(collision.transform.position, CristalRoto);

            // Destruir el objeto original y la bala
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            // Destruir la bala en otros casos
            Destroy(gameObject);
        }
    }

    private void PlaySoundAtPosition(Vector3 position, AudioClip clip)
    {
        // Crear un nuevo GameObject temporal para el sonido
        GameObject soundGameObject = new GameObject("TempAudio");
        soundGameObject.transform.position = position;

        // Añadir y configurar el AudioSource
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;

        // Asignar valores aleatorios de pitch y volumen
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.volume = Random.Range(minVolume, maxVolume);

        // Reproducir el sonido
        audioSource.Play();

        // Destruir el GameObject temporal después de que el sonido haya terminado
        Destroy(soundGameObject, clip.length);
    }
}
