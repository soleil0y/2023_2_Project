using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class StartSceneManager : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject LoadCanvas;
    public GameObject EndCanvas;

    public Text deathCountText;

    public Text saveStatusText;

    private int sceneNum;
    private int spawnNum;
    private int deathCount;
    private bool flashlight;
    private bool map;
    private bool pillow;

    private bool hasSavedData;

    void Start()
    {
        hasSavedData = PlayerPrefs.HasKey("save_SceneNum");

        if (hasSavedData) saveStatusText.color = new Color(255, 255, 255);
        else saveStatusText.color = new Color(90, 90, 90);
    }

    void Awake()
    {
        if (GameManager.instance != null && GameManager.instance.gameEnd)
        {
            StartCanvas.SetActive(false);
            LoadCanvas.SetActive(false);
            EndCanvas.SetActive(true);

            deathCountText.text = GameManager.instance.deathCount.ToString();
        }
    }

    public void MainBtn()
    {
        StartCanvas.SetActive(false);
        LoadCanvas.SetActive(true);
    }

    public void StartBtn()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.deathCount = 0;
    }
    
    public void LoadBtn()
    {
        if (hasSavedData)
        {
            LoadData();
            GameManager.instance.deathCount = deathCount;
            GameManager.instance.isPickedUp = flashlight;
            GameManager.instance.is2222 = map;
            GameManager.instance.isPickPillow = pillow;

            SceneManager.LoadScene(sceneNum);
        }
    }

    void LoadData()
    {
        sceneNum = PlayerPrefs.GetInt("save_SceneNum", 0);
        spawnNum = PlayerPrefs.GetInt("save_SpawnNum", 0);
        deathCount = PlayerPrefs.GetInt("save_DeathCount", 0);
        flashlight = PlayerPrefs.GetInt("save_Flashlight", 0) == 1;
        map = PlayerPrefs.GetInt("save_Map", 0) == 1;
        pillow = PlayerPrefs.GetInt("save_Pillow", 0) == 1;
    }

}
