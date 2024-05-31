using UnityEngine;

public class Level6Logic : MonoBehaviour
{
    //public GameObject explosionEffect; // Prefab de efecto de explosi�n
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
        // L�gica adicional para manejar la explosi�n, como destruir la bomba, etc.
    }
}
