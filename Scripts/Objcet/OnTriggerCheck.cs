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
                SpawnManager._instance.GetKey();
                SpawnManager._instance.keyUI.SetActive(false);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Dool"))
        {
            if (SpawnManager._instance.GetKeyCheck())
            {
                if (Input.GetKey(KeyCode.E))
                {
                    SpawnManager._instance.DoolOpen();
                    SpawnManager._instance.keyUI.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            SpawnManager._instance.keyUI.SetActive(true);
        }

        if (other.gameObject.CompareTag("Dool") && SpawnManager._instance.GetKeyCheck())
        {
            SpawnManager._instance.keyUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("asdf");
            SpawnManager._instance.keyUI.SetActive(false);
        }

        if (other.gameObject.CompareTag("Dool") && SpawnManager._instance.GetKeyCheck())
        {
            SpawnManager._instance.keyUI.SetActive(false);
        }
    }
}
