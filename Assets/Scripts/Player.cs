using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHP = 3;
    public static int playerHP;
    //이거나중에 체력 올릴 일 잇으면 max를..
    //그냥 체력을 없애는 방향으로..


    public Text hpText;
    public int bounceForce = 10;
    private PM playerMoveScript;

    public GameObject gameOverUI;

    public GameObject playerLight;

    void Start()
    {
        playerMoveScript = GetComponent<PM>();
        if(/*&&*/playerLight != null)
        {
            playerLight.SetActive(true);
        }
    }

    private void OnEnable()
    {
        playerHP = maxHP;
        hpText.text = playerHP.ToString();
    }


    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("qq"); 
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            playerHP -= 1;
            hpText.text = playerHP.ToString();
            Debug.Log("dddd"+other.gameObject.name);

            Vector3 bounceDirection = other.contacts[0].normal;

            playerMoveScript.enabled = false;
            GetComponent<Rigidbody>().AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            playerMoveScript.enabled = true;

            if (playerHP <= 0) gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (gameOverUI != null) gameOverUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hp")
        {
            other.gameObject.SetActive(false);
            playerHP = maxHP;
            hpText.text = playerHP.ToString();
        }
    }
}

/*
 * 에집중을..
 */

//납득이되게..

//내일할일 플레이어체력부분(플레이어-적)
//         플레이어이동을 CC말고 Rigidbody 쓰는쪽도 생각해보기
//         손전등 타격부분(손전등-적)
// w지금 ㅊ[력 텍스트부분을 체력에 변화가 생길 때만 갱신해주고 있는데..(활성화 ㅣㅂ활성화 충돌 회복)
// 걍 업데이트문ㅇ ㅐㅣ넣는게 나을지..
//v걍 플레이어 체력을 없애는걸로(ㄹㅇ)
