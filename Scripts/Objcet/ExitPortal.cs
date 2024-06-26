using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    bool isfirst = true;

    private void OnTriggerEnter(Collider portal)
    {
        if (portal.gameObject.CompareTag("Portal") && isfirst)
        {
            Vector3 portalPos = portal.transform.position;
            SpawnManager._instance.Portal(portalPos, this.gameObject);
            isfirst = false;
        }
    }
}
