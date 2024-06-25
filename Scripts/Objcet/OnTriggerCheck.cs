using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerCheck : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.GetKey();
                GameManager.Instance.keyUI.SetActive(false);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Dool"))
        {
            if (GameManager.Instance.GetKeyCheck() && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("¹®¿­¸²~");
                GameManager.Instance.DoolOpen();
                GameManager.Instance.keyUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            GameManager.Instance.keyUI.SetActive(true);
        }

        if (other.gameObject.CompareTag("Dool") && GameManager.Instance.GetKeyCheck())
        {
            GameManager.Instance.keyUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("asdf");
            GameManager.Instance.keyUI.SetActive(false);
        }

        if (other.gameObject.CompareTag("Dool") && GameManager.Instance.GetKeyCheck())
        {
            GameManager.Instance.keyUI.SetActive(false);
        }
    }
}
