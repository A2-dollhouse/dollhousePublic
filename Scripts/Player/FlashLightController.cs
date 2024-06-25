
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public GameObject flashLight;
    private bool isOn = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    public void ToggleFlashlight()
    {
        isOn = !isOn;
        if (!isOn)
        {
            flashLight.SetActive(false);
        }
        else
        {
            flashLight.SetActive(true);
        }
    }
}
