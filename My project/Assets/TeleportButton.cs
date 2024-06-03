using UnityEngine;
using UnityEngine.UI;

public class TeleportButton : MonoBehaviour
{
    public Transform playerTransform; // El Transform del jugador
    public Transform destinationTransform; // El Transform de la posición de destino

    public void TeleportPlayer()
    {
        if (playerTransform != null && destinationTransform != null)
        {
            playerTransform.position = destinationTransform.position;
            Debug.Log("Player teleported to: " + destinationTransform.position);
        }
        else
        {
            Debug.LogError("Player Transform or Destination Transform is not assigned.");
        }
    }
}
