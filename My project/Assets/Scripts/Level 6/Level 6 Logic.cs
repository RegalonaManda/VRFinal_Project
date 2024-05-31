using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6Logic : MonoBehaviour
{
    //public GameObject explosionEffect; // Prefab de efecto de explosi�n
    public Cable[] correctOrder; // Array de cables en el orden correcto
    private int currentCutIndex = 0;
    [SerializeField] private CAInController cainController;
    [SerializeField] private FadeController fadeController;

    private void Start()
    {
        cainController.PlayIntroLevel6();
    }
    public void CableCut(Cable cutCable)
    {
        if (correctOrder[currentCutIndex] == cutCable)
        {
            currentCutIndex++;
            if (currentCutIndex >= correctOrder.Length)
            {
                cainController.PlayfinishLevel6();
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
        SceneManager.LoadScene("BasicScene");
        // L�gica adicional para manejar la explosi�n, como destruir la bomba, etc.
    }
}
