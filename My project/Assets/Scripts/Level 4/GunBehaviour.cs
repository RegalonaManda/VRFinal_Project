using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Animator animator;  // Referencia al componente Animator
    private static readonly int ShootTrigger = Animator.StringToHash("ShootTrigger"); // Hash para el Trigger

    private void Update()
    {
        // Aqu� puedes usar tu propio sistema de entrada para el disparo
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" por tu input espec�fico si es necesario
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Activa el trigger de disparo en el Animator
        animator.SetTrigger(ShootTrigger);

        // Aqu� puedes a�adir l�gica adicional de disparo, como instanciar balas, efectos de sonido, etc.
        FireBullet();
    }

    private void FireBullet()
    {
        // A�ade tu l�gica de disparo aqu�
        Debug.Log("Bullet Fired!");
    }
}
