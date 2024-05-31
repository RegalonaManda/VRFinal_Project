using UnityEngine;

public class Level6Logic : MonoBehaviour
{
    //public GameObject explosionEffect; // Prefab de efecto de explosión
    public Cable[] correctOrder; // Array de cables en el orden correcto
    private int currentCutIndex = 0;

    public void CableCut(Cable cutCable)
    {
        if (correctOrder[currentCutIndex] == cutCable)
        {
            currentCutIndex++;
            if (currentCutIndex >= correctOrder.Length)
            {
                Debug.Log("Bomb defused!");
            }
        }
        else
        {
            Explode();
        }
    }

    void Explode()
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Debug.Log("Bomb exploded!");
        // Lógica adicional para manejar la explosión, como destruir la bomba, etc.
    }
}
