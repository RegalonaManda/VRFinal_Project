using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    // Ajusta esto si la bala debe causar da�o
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        // Realizar acciones cuando la bala colisiona con otro objeto
        Debug.Log("Bala ha colisionado con: " + collision.gameObject.name);

        // Ejemplo: Si la bala colisiona con un enemigo, causar da�o al enemigo
        if (collision.gameObject.CompareTag("Diana"))
        {
            // Aqu� puedes realizar acciones espec�ficas para causar da�o al enemigo
            // Por ejemplo, puedes llamar a una funci�n en el script del enemigo para reducir su salud
            // collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            
            // Destruye la bala
            Destroy(gameObject);
        }
        // Ejemplo: Si la bala colisiona con otro objeto que no es el enemigo, simplemente la destruimos
        else
        {
            Destroy(gameObject);
        }
    }
}

