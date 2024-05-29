using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Apply forward force to instantiated prefab
    /// </summary>
    public class LaunchProjectile : MonoBehaviour
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

        [SerializeField]
        [Tooltip("The Line Renderer to visualize the raycast")]
        LineRenderer m_LineRenderer = null;

        private bool isCollidingWithPlayer = false;

        private void Start()
        {
            // Ensure LineRenderer is configured
            if (m_LineRenderer != null)
            {
                m_LineRenderer.positionCount = 2;
                m_LineRenderer.startWidth = 0.05f;
                m_LineRenderer.endWidth = 0.05f;
                m_LineRenderer.enabled = false; // Hide by default
            }
        }

        public void Fire()
        {
            // Check if the gun is pointing towards the player or colliding with the player
            if (IsPointingAtPlayer() || isCollidingWithPlayer)
            {
                GameObject newObject = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation, null);

                if (newObject.TryGetComponent(out Rigidbody rigidBody))
                    ApplyForce(rigidBody);
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

            // Visualize the Raycast using LineRenderer
            if (m_LineRenderer != null)
            {
                m_LineRenderer.SetPosition(0, ray.origin);
                m_LineRenderer.SetPosition(1, ray.origin + ray.direction * 100f);
                m_LineRenderer.enabled = true; // Show the line

                // Optionally hide the line after a short duration
                Invoke(nameof(HideLineRenderer), 0.1f); // Hide after 0.1 seconds
            }

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

        private void HideLineRenderer()
        {
            if (m_LineRenderer != null)
            {
                m_LineRenderer.enabled = false;
            }
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
}
