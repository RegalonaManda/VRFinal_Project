using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootconfetti : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The projectile that's created")]
    GameObject m_ProjectilePrefab = null;

    [SerializeField]
    [Tooltip("The point that the project is created")]
    Transform m_StartPoint = null;

    [SerializeField]
    [Tooltip("The speed at which the projectile is launched")]
    float m_LaunchSpeed = 1.0f;

    [SerializeField]
    [Tooltip("The Collider of the player")]
    Collider m_PlayerCollider = null;

    [SerializeField] private Level5Logic level5logic;

    private bool isCollidingWithPlayer = false;

    public void Fire()
    {
        // Check if the gun is pointing towards the player or colliding with the player
        if (IsPointingAtPlayer() || isCollidingWithPlayer)
        {
            GameObject newObject = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation, null);
            level5logic.Minigame5Finished();
            if (newObject.TryGetComponent(out Rigidbody rigidBody))
            {
                ApplyForce(rigidBody);
            }
        }
    }

    void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
        rigidBody.AddForce(force);
    }

    bool IsPointingAtPlayer()
    {
        Ray ray = new Ray(m_StartPoint.position, m_StartPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object is the player
            if (hit.collider == m_PlayerCollider)
            {
                return true;
            }
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == m_PlayerCollider)
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider == m_PlayerCollider)
        {
            isCollidingWithPlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == m_PlayerCollider)
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == m_PlayerCollider)
        {
            isCollidingWithPlayer = false;
        }
    }
}
