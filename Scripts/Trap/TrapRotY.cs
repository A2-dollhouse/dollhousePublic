using UnityEngine;

public class TrapRotY : TrapController
{
    public float rotationSpeed = 300;
    public bool rotationDir;

    void FixedUpdate()
    {
        RotationAbs();

        Transform objectTransform = transform;

        Quaternion currentRotation = objectTransform.rotation;

        Quaternion deltaRotation = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);

        objectTransform.rotation = currentRotation * deltaRotation;
    }

    private void RotationAbs()
    {
        if (rotationDir)
        {
            rotationSpeed = Mathf.Abs(rotationSpeed);
        }
        else
        {
            rotationSpeed = -Mathf.Abs(rotationSpeed);
        }
    }
}