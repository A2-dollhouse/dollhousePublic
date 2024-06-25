using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform headTransform;
    public Transform cameraTransform;

    void Update()
    {
        if (headTransform != null && cameraTransform != null)
        {
            headTransform.LookAt(cameraTransform);
        }
    }
}