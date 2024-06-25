using System.Collections.Generic;
using UnityEngine;


public class TrapTrigger : MonoBehaviour
{
    public bool onTriggerEnter = false;
    public bool onTriggerExit = false;
    private bool hasActivated = false;

    public List<GameObject> trapObjects;

    void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnter)
        {
            if (!hasActivated && other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                for (int i = 0; i < trapObjects.Count; i++)
                {
                    if (trapObjects != null && !trapObjects[i].activeSelf)
                    {
                        trapObjects[i].SetActive(true);
                        hasActivated = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(onTriggerExit)
        {
            if (!hasActivated && other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                for (int i = 0; i < trapObjects.Count; i++)
                {
                    if (trapObjects != null && !trapObjects[i].activeSelf)
                    {
                        trapObjects[i].SetActive(true);
                        hasActivated = true;
                    }
                }
            }
        }
    }
}
