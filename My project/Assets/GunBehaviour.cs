using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Animator animator;  // Referencia al componente Animator
    private static readonly int ShootTrigger = Animator.StringToHash("ShootTrigger"); // Hash para el Trigger

    private void Update()
    {
        // Aquí puedes usar tu propio sistema de entrada para el disparo
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" por tu input específico si es necesario
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Activa el trigger de disparo en el Animator
        animator.SetTrigger(ShootTrigger);

        // Aquí puedes añadir lógica adicional de disparo, como instanciar balas, efectos de sonido, etc.
        FireBullet();
    }

    private void FireBullet()
    {
        // Añade tu lógica de disparo aquí
        Debug.Log("Bullet Fired!");
    }
}
