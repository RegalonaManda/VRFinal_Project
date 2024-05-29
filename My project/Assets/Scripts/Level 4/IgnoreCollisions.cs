using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    // Assign these in the Inspector
    public Collider SliderColl;
    public Collider GripColl;
    public Collider MagazineColl;

    void Start()
    {
        if (GripColl != null && MagazineColl != null)
        {
            Physics.IgnoreCollision(GripColl, MagazineColl, true);
        }
        if (SliderColl != null && MagazineColl != null)
        {
            Physics.IgnoreCollision(SliderColl, MagazineColl, true);
        }
    }
}
