using UnityEngine;

public class Cable : MonoBehaviour
{
    public GameObject brokenCable;  // Referencia al cable roto
    public Level6Logic level6Logic; // Referencia al script del nivel

    private bool isCut = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife") && !isCut)
        {
            isCut = true;
            CutCable();
        }
    }

    void CutCable()
    {
        // Desactiva el cable entero y activa el cable roto
        gameObject.SetActive(false);
        brokenCable.SetActive(true);

        // Notifica al Level6Logic que se ha cortado un cable
        level6Logic.CableCut(this);
    }
}
