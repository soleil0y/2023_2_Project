using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//t������ �ݴ� ��ũ��Ʈ

public class PickUpFlash : MonoBehaviour
{
    private void Awake()
    {
        if(GameManager.instance.isPickedUp) gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.instance.isPickedUp)
        {
            //flashlight.gameObject.SetActive(true);
            GameManager.instance.isPickedUp = true;
            gameObject.SetActive(false);
        }
    }
}

//+) ���߿� �����������Ʈ �������̰� �߰����� 