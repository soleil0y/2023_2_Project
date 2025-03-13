using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//t손전등 줍는 스크립트

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

//+) 나중에 손전등오브젝트 눈에보이게 추가ㄱㄱ 