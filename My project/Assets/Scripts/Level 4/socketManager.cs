using System.Collections.Generic;
using UnityEngine;

public class MagazineSocketManager : MonoBehaviour
{
    public List<Transform> sockets = new List<Transform>(); // Lista de sockets

    public Transform GetSocketWithMagazine()
    {
        foreach (Transform socket in sockets)
        {
            if (socket.childCount > 0)
            {
                return socket; // Devolver el primer socket con un hijo (cargador)
            }
        }
        return null; // No hay cargador en ningún socket
    }
}
