using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHP = 3;
    public static int playerHP;
    //�̰ų��߿� ü�� �ø� �� ������ max��..
    //�׳� ü���� ���ִ� ��������..


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
 * ��������..
 */

//�����̵ǰ�..

//�������� �÷��̾�ü�ºκ�(�÷��̾�-��)
//         �÷��̾��̵��� CC���� Rigidbody �����ʵ� �����غ���
//         ������ Ÿ�ݺκ�(������-��)
// w���� ��[�� �ؽ�Ʈ�κ��� ü�¿� ��ȭ�� ���� ���� �������ְ� �ִµ�..(Ȱ��ȭ �Ӥ�Ȱ��ȭ �浹 ȸ��)
// �� ������Ʈ���� ���ӳִ°� ������..
//v�� �÷��̾� ü���� ���ִ°ɷ�(����)
