using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSceneLoad : MonoBehaviour
{
    public int targetSceneNum;
    public int RoomSpawnNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           //Debug.Log("¾À ³Ñ¾î°¨..");

            PlayerManager.spawnPointNum = RoomSpawnNum;
            //Debug.Log("¤·:" + GameManager.instance.spawnPointNum + RoomSpawnNum);

            SceneManager.LoadScene(targetSceneNum);
        }
    }

    public void MoveScene()
    {
        //Debug.Log("¾À ³Ñ¾î°¨..");

        PlayerManager.spawnPointNum = RoomSpawnNum;
        //Debug.Log("¤·:" + GameManager.instance.spawnPointNum + RoomSpawnNum);

        SceneManager.LoadScene(targetSceneNum);
    }

}
