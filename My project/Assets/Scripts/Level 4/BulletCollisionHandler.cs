using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public int damageAmount = 10;

    // Referencias a los clips de sonido


    public AudioClip CristalRoto;
    public AudioSource audioSource;
    private Level4Logic level4logic;
    public GameObject dianaPrefab;

    private void Start()
    {
        level4logic = FindObjectOfType<Level4Logic>();
        if (level4logic == null)
        {
            Debug.LogError("No se encontró Level4Logic en la escena.");
        }

        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró AudioSource en el objeto de bala.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Diana"))
        {
            // Reproducir sonido de acierto
      

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
            audioSource.Play();
            PlaySound(CristalRoto);

            // Aplicar la misma velocidad y rotación angular a todos los rigidbodies en el nuevo prefab
            Rigidbody[] newRbs = newDiana.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody newRb in newRbs)
            {
                newRb.velocity = originalVelocity;
                newRb.angularVelocity = originalAngularVelocity;
            }

            // Destruir el objeto original y la bala
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            // Reproducir sonido de impacto
           
            Destroy(gameObject);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
