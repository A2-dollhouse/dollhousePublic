using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _instance;

    [Header("[Key random respawn]")]
    public List<GameObject> keySpawnPoint;
    public GameObject key;
    public GameObject keyUI;
    public TextMeshProUGUI keyCountUI;

    public int keySpawnCount;

    //열쇠 획득한 량
    public int getKeyCount;

    [Header("[ExitDool]")]
    public List<GameObject> doolSpawnPoint;
    public GameObject exitPortalIn;
    public GameObject exitPortalOut;
    public GameObject exitDool;
    public GameObject exitDoolWool;


    private void Awake()
    {
        if(null == _instance)
        {
            _instance = this;
        }
    }

    void Start()
    {
        KeySpawn();
        DoolSpawn();
        SoundManager.Instance.sfxSource.Play();
    }

    //열쇠 프리팹을 키 리스폰 포인트(정해진 위치)에 랜덤으로 생성 하는 매서드
    public void KeySpawn()
    {
        for (int i = 0; i < keySpawnCount; i++)
        {
            int num = 0;
            while (true)
            {
                num = Random.Range(0, keySpawnPoint.Count);

                if (keySpawnPoint[num].transform.childCount == 0)
                    break;
            }
            GameObject spawnKey = Instantiate(key, keySpawnPoint[num].transform.position, Quaternion.identity);
            spawnKey.transform.SetParent(keySpawnPoint[num].transform, true);
        }
        keyCountUI.text = "Key : " + getKeyCount + " / " + keySpawnCount;
    }

    //문 프리팹을 문 리스폰 포인트(정해진 위치)에 랜덤으로 생성 하는 매서드
    public void DoolSpawn()
    {
        Vector3 lot = new Vector3(-90f, 0, 0);
        Vector3 gap = new Vector3(0, 0.45f, 0);

        int num = 0;
        num = Random.Range(0, doolSpawnPoint.Count);
        GameObject spawnDool = Instantiate(exitDool, doolSpawnPoint[num].transform.position + gap, Quaternion.Euler(lot));
        spawnDool.transform.SetParent(doolSpawnPoint[num].transform, true);

        exitDoolWool = spawnDool.transform.GetChild(1).gameObject;
        exitPortalIn = spawnDool.transform.GetChild(2).gameObject;
    }

    //포탈에 닿았을 때 반대편 포탈로 이동하는 매서드
    public void Portal(Vector3 portalPos, GameObject player)
    {
        player.transform.position = exitPortalOut.transform.position;
    }

    public void GetKey()
    {
        SoundManager.Instance.PlayPlayerSFX(PlayerSfxSound.KeyGet);
        getKeyCount++;
        keyCountUI.text = "Key : " + getKeyCount + " / " + keySpawnCount;
        if (GetKeyCheck())
        {
            exitPortalIn.SetActive(true);
            keyCountUI.color = new Color32(255, 255, 0, 255);
            SoundManager.Instance.PlayPlayerSFX(PlayerSfxSound.KeyAll);
        }
    }

    public bool GetKeyCheck()
    {
        return getKeyCount == keySpawnCount;
    }

    public void DoolOpen()
    {
        Debug.Log("문열림~");
        SoundManager.Instance.PlayPlayerSFX(PlayerSfxSound.KeyOpen);
        exitDoolWool.SetActive(false);
    }
}
