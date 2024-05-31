using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject dianaPrefab; // Prefab de la diana a disparar
    public Transform firePoint;    // Punto de disparo del ca��n
    public Transform target;       // Objeto objetivo para disparar
    public float fireForce = 10f;  // Fuerza con la que se disparar�n las dianas
    public float fireRate = 1f;    // Cadencia de disparo (dianas por segundo)
    private float nextFireTime;    // Tiempo para el pr�ximo disparo

    void Start()
    {
        // Inicializar el tiempo del pr�ximo disparo
        nextFireTime = Time.time + 1f / fireRate;
    }

    void Update()
    {
        // Comprobar si es el momento de disparar
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate; // Actualizar el tiempo del pr�ximo disparo
        }
    }

    void Fire()
    {
        // Instanciar una nueva diana en el punto de disparo con rotaci�n adicional en el eje X
        Quaternion rotation = firePoint.rotation * Quaternion.Euler(90f, 0f, 0f);
        GameObject dianaInstance = Instantiate(dianaPrefab, firePoint.position, rotation);

        // Aplicar una fuerza a la diana para dispararla
        Rigidbody rb = dianaInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calcular la direcci�n hacia el objetivo
            Vector3 direction = (target.position - firePoint.position).normalized;
            rb.AddForce(direction * fireForce, ForceMode.Impulse);
        }
    }
}
