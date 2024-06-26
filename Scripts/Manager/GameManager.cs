using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("[Player]")]
    public Player player;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
