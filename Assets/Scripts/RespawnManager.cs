using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject[] spawnpoint;
    public GameObject player;

    public void PlayerSpawn()
    {
        player.SetActive(true);
        player.transform.position = spawnpoint[PlayerManager.spawnPointNum].transform.position;
    }

    private void OnEnable()
    {
        Debug.Log("RespawnMgr_OnEnable");

        //Debug.Log(PlayerManager.spawnPointNum);
        player.transform.position = spawnpoint[PlayerManager.spawnPointNum].transform.position;
    }
}
