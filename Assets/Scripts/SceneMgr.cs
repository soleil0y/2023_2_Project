using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public GameObject gameOption;
    int sceneNum;
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOption.activeSelf)
            {
                Debug.Log("esc+esc");
                CloseOptionWindow();
            }
            else
            {
                Debug.Log("옵션창을열다");
                OpenOptionWindow();
            }
        }
    }

    public void OpenOptionWindow() //옵션창열기
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseOptionWindow() //계속하기...
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveGame() //wj저장..
    {   
        SaveData(sceneNum, PlayerManager.spawnPointNum, GameManager.instance.deathCount, GameManager.instance.isPickedUp, GameManager.instance.is2222, GameManager.instance.isPickPillow);

        Debug.Log("Saved SceneNum: " + PlayerPrefs.GetInt("save_SceneNum"));
        Debug.Log("Saved SpawnNum: " + PlayerPrefs.GetInt("save_SpawnNum"));
        Debug.Log("Saved DeathCount: " + PlayerPrefs.GetInt("save_DeathCount"));
        Debug.Log("Saved Flashlight: " + PlayerPrefs.GetInt("save_Flashlight"));
        Debug.Log("Saved Map: " + PlayerPrefs.GetInt("save_Map"));
        Debug.Log("Saved Pillow: " + PlayerPrefs.GetInt("save_Pillow"));
    }

    public void SaveAndQuit() //wj저장및종료..
    {
        SaveGame();
        Application.Quit();
    }

    public void SaveData(int sceneNum, int spawnNum, int deathCount, bool flashlight, bool map ,bool pillow)
    {
        PlayerPrefs.SetInt("save_SceneNum", sceneNum);
        PlayerPrefs.SetInt("save_SpawnNum", spawnNum);
        PlayerPrefs.SetInt("save_DeathCount", deathCount);
        PlayerPrefs.SetInt("save_Flashlight", flashlight ? 1 : 0);
        PlayerPrefs.SetInt("save_Map", map ? 1 : 0);
        PlayerPrefs.SetInt("save_Pillow", pillow ? 1 : 0);
    }
}
