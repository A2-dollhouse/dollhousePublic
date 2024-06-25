using UnityEngine;
using System.Collections;

public class DollController : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardForce = 10f;
    public bool isMoving = true;
    public float deactivateDelay = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DeactivateObject(deactivateDelay));
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(transform.forward * forwardForce);
        }
    }

    private IEnumerator DeactivateObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}