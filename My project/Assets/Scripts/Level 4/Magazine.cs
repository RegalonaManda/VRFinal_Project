using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int maxAmmo = 8; // Máximo de balas en el cargador
    public int currentAmmo; // Balas restantes en el cargador

    void Start()
    {
        currentAmmo = maxAmmo; // Inicializamos el cargador lleno
    }

    public bool HasAmmo()
    {
        return currentAmmo > 0;
    }

    public void UseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
        }
    }

    public void Reload()
    {
        currentAmmo = maxAmmo; // Recargar el cargador
    }
}
