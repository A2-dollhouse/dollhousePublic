using UnityEngine;

public class TrapSlide : TrapController
{
    public float moveDistance = 2.0f;
    public float moveSpeed = 2.0f;

    public float rotationSpeed = 300f;
    public Vector3 moveDirection = Vector3.forward;
    public bool rotationDirClockwise = true;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + moveDirection * moveDistance;
    }

    void FixedUpdate()
    {
        float step = moveSpeed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movingForward ? targetPos : startPos, step);

        if (transform.position == targetPos)
        {
            movingForward = false;
        }
        else if (transform.position == startPos)
        {
            movingForward = true;
        }

        // 회전 처리
        RotateObject();
    }

    private void RotateObject()
    {
        int rotateDirection = rotationDirClockwise ? 1 : -1;

        float rotateAmount = rotationSpeed * Time.deltaTime * rotateDirection;
        transform.Rotate(Vector3.up, rotateAmount);
    }
}