using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    // Ajusta esto si la bala debe causar daño
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        // Realizar acciones cuando la bala colisiona con otro objeto
        Debug.Log("Bala ha colisionado con: " + collision.gameObject.name);

        // Ejemplo: Si la bala colisiona con un enemigo, causar daño al enemigo
        if (collision.gameObject.CompareTag("Diana"))
        {
            // Aquí puedes realizar acciones específicas para causar daño al enemigo
            // Por ejemplo, puedes llamar a una función en el script del enemigo para reducir su salud
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

