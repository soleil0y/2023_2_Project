using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isPickedUp = false;
    public bool is2222 = false;
    public bool isPickPillow = false;
    public bool gameEnd = false;

    public int deathCount = 0;

    public static GameManager instance = null;

    private void Awake()
    {
        Debug.Log("gameMgr");

        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); //씬이 로드되어도 유지
        }
        else
        {
            if (instance != this) 
                Destroy(this.gameObject); //존재겹침->삭제..
        }
    }

}
