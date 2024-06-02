using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;  // The duration of the shake
    public float shakeMagnitude = 0.2f;  // The magnitude of the shake

    private Vector3 originalPos;  // Original position of the camera rig or the parent object
    private Transform cameraRig;

    void Start()
    {
        cameraRig = transform.parent;  // Assuming the script is attached to the camera
        if (cameraRig != null)
        {
            originalPos = cameraRig.localPosition;
        }
        else
        {
            Debug.LogError("VRShakeEffect should be attached to the camera inside a rig");
        }
    }

    public void StartShake()
    {
        if (cameraRig != null)
        {
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            float z = Random.Range(-1f, 1f) * shakeMagnitude;

            cameraRig.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z + z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraRig.localPosition = originalPos;
    }
}
