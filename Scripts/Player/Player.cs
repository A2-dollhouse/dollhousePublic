using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public event Action OnDeathEvent;

    public GameObject PlayerObject;
    public GameObject diePlayerObject;

    public int respawnTime = 2;


    public void OnDeath()
    {
        diePlayerObject.SetActive(true);
        diePlayerObject.transform.position = PlayerObject.transform.position;
        PlayerObject.SetActive(false);
        OnDeathEvent?.Invoke();
    }

    public void OnRespawn()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(1);
        PlayerObject.SetActive(true);
        diePlayerObject.SetActive(false);
    }

    
}
