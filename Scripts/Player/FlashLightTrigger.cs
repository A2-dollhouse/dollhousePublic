using System.Collections.Generic;
using UnityEngine;

public class FlashLightTrigger : MonoBehaviour
{
    public FlashLightController flashLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            flashLight.ToggleFlashlight();
        }
    }
}
