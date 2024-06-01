using UnityEngine;

public class SelfDestructor : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "DestroyPlate"
        if (collision.gameObject.CompareTag("DestroyPlate"))
        {
            // Destruimos el GameObject al que este script está adjunto
            Destroy(gameObject);
        }
    }

}
