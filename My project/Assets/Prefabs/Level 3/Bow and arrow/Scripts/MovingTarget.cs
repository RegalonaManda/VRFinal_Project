using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private bool stopped = false;

    private Vector3 nextposition;

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float arriveThreshold = 0.1f, speed = 1f;

    [SerializeField]
    private Transform pointA, pointB; // Endpoints for vertical movement

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        nextposition = pointA.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!rb.isKinematic && collision.gameObject.CompareTag("Arrow"))
        {
            audioSource.Play();

            // Disable the arrow's physics
            Rigidbody arrowRb = collision.gameObject.GetComponent<Rigidbody>();
            if (arrowRb != null)
            {
                arrowRb.isKinematic = true;
                arrowRb.transform.SetParent(transform); // Parent the arrow to the target
            }
        }
    }

    public void GetHit()
    {
        health--;
        if (health <= 0)
        {
            rb.isKinematic = false;
            stopped = true;
        }
    }

    private void FixedUpdate()
    {
        if (!stopped)
        {
            if (Vector3.Distance(transform.position, nextposition) < arriveThreshold)
            {
                nextposition = (nextposition == pointA.position) ? pointB.position : pointA.position;
            }

            Vector3 direction = nextposition - transform.position;
            rb.MovePosition(transform.position + direction.normalized * Time.fixedDeltaTime * speed);
        }
    }
}

public interface IHittable
{
    void GetHit();
}
