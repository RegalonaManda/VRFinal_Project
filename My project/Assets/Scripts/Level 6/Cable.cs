using UnityEngine;

public class Cable : MonoBehaviour
{
    public GameObject brokenCable;  // Referencia al cable roto
    public Level6Logic level6Logic; // Referencia al script del nivel
    public ParticleSystem cutParticles;  // Referencia al sistema de partículas

    private bool isCut = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife") && !isCut)
        {
            isCut = true;
            CutCable(other);
            level6Logic.CableCut(this);
        }
    }

    void CutCable(Collider other)
    {
        // Desactiva el cable entero y activa el cable roto
        gameObject.SetActive(false);
        brokenCable.SetActive(true);

        // Reproducir partículas en la posición del collider del cable
        if (cutParticles != null)
        {
            ParticleSystem particles = Instantiate(cutParticles, other.transform.position, Quaternion.identity);
            particles.Play();
            Destroy(particles.gameObject, particles.main.duration);
        }

        // Notifica al Level6Logic que se ha cortado un cable
        //level6Logic.CableCut(this);
    }
}
