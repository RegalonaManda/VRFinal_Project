using UnityEngine;

public class BowIgnoreCollisions : MonoBehaviour
{
    // Assign these in the Inspector
    public Collider bowCollider;
    public GameObject arrowPrefab;
    public GameObject stickingArrowPrefab;

    void Start()
    {
        // Ignore collisions between bowCollider and arrowPrefab
        if (bowCollider != null && arrowPrefab != null)
        {
            Collider[] arrowColliders = arrowPrefab.GetComponentsInChildren<Collider>();
            foreach (Collider arrowCollider in arrowColliders)
            {
                Physics.IgnoreCollision(bowCollider, arrowCollider, true);
            }
        }

        // Ignore collisions between bowCollider and stickingArrowPrefab
        if (bowCollider != null && stickingArrowPrefab != null)
        {
            Collider[] stickingArrowColliders = stickingArrowPrefab.GetComponentsInChildren<Collider>();
            foreach (Collider stickingArrowCollider in stickingArrowColliders)
            {
                Physics.IgnoreCollision(bowCollider, stickingArrowCollider, true);
            }
        }

        // Optionally, ignore collisions between arrowPrefab and stickingArrowPrefab
        if (arrowPrefab != null && stickingArrowPrefab != null)
        {
            Collider[] arrowColliders = arrowPrefab.GetComponentsInChildren<Collider>();
            Collider[] stickingArrowColliders = stickingArrowPrefab.GetComponentsInChildren<Collider>();

            foreach (Collider arrowCollider in arrowColliders)
            {
                foreach (Collider stickingArrowCollider in stickingArrowColliders)
                {
                    Physics.IgnoreCollision(arrowCollider, stickingArrowCollider, true);
                }
            }
        }
    }
}
