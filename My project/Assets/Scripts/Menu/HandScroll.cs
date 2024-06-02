using UnityEngine;
using UnityEngine.UI;

public class HandScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Transform leftHand;
    public Transform rightHand;

    private Vector3 lastLeftHandPosition;
    private Vector3 lastRightHandPosition;
    private bool isScrolling;

    void Start()
    {
        if (leftHand == null || rightHand == null)
        {
            Debug.LogError("Hand transforms not assigned.");
            enabled = false;
        }
    }

    void Update()
    {
        // Check for hand proximity or gesture to start scrolling
        if (IsHandNearScrollArea(leftHand) || IsHandNearScrollArea(rightHand))
        {
            isScrolling = true;
            lastLeftHandPosition = leftHand.position;
            lastRightHandPosition = rightHand.position;
        }

        if (isScrolling)
        {
            Vector3 leftHandDelta = leftHand.position - lastLeftHandPosition;
            Vector3 rightHandDelta = rightHand.position - lastRightHandPosition;

            float scrollDelta = leftHandDelta.y + rightHandDelta.y;

            scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition - scrollDelta);

            lastLeftHandPosition = leftHand.position;
            lastRightHandPosition = rightHand.position;

            if (!IsHandNearScrollArea(leftHand) && !IsHandNearScrollArea(rightHand))
            {
                isScrolling = false;
            }
        }
    }

    private bool IsHandNearScrollArea(Transform hand)
    {
        // Implement a method to determine if the hand is near the scroll area
        // This can be based on distance, collider triggers, or other criteria
        return Vector3.Distance(hand.position, scrollRect.transform.position) < 0.1f;
    }
}
