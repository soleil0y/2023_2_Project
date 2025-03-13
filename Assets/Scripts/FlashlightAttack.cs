using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("손전등 충돌ㅇㅇ..");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("손전등-적 충돌감지");
            other.gameObject.SetActive(false);
        }
    }
}
