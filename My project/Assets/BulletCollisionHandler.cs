using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    // Ajusta esto si la bala debe causar da�o
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bala ha colisionado con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Diana"))
        {
            Debug.Log("Colisi�n con Diana detectada. Destruyendo ambos objetos.");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Colisi�n con otro objeto. Destruyendo la bala.");
            Destroy(gameObject);
        }
    }

}

