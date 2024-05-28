using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destruye la diana al ser impactada por una bala
            Destroy(gameObject);
        }
    }
}
