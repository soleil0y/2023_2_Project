using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //체력삭제..원샷원킬

    public GameObject gameOverUI;
    public GameObject dieEffect;
    public GameObject playerPillow;

    public GameObject gameEndUI;

    ParticleSystem ps;
    AudioSource deathSound;

    public static int spawnPointNum;

    void Start()
    {
        ps = dieEffect.GetComponent<ParticleSystem>();
        ps.Play();
        deathSound = GetComponent<AudioSource>();
    }

    void Awake()
    {
        if (GameManager.instance != null && GameManager.instance.isPickPillow)
        {
            playerPillow.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.deathCount++;
            Invoke("EnableGameOverUI", ps.main.duration + 0.3f);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            int.TryParse(other.gameObject.name, out spawnPointNum);
            //Debug.Log("위치저장..");
        }
        if (other.gameObject.tag == "Pillow")
        {
            GameManager.instance.isPickPillow = true;
            playerPillow.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Bed" && GameManager.instance.isPickPillow)
        {
            playerPillow.SetActive(false);
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }
            GameManager.instance.gameEnd = true;
            Invoke("EnableGameEnd", 1.5f);

        }
    }

    private void OnEnable()
    {
        if (gameOverUI != null && gameOverUI.activeSelf) gameOverUI.SetActive(false);
        //    Debug.Log("PlayerMgr_OnEnable");
    }

    private void OnDisable()
    {
        deathSound.Play();

        if (dieEffect != null)
        {
            dieEffect.SetActive(true);
            dieEffect.transform.position = transform.position;
            ps.Play();
        }
    }

    void EnableGameOverUI()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    void EnableGameEnd()
    {
        SceneManager.LoadScene(0);
    }
}


