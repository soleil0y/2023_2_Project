using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("������ �浹����..");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("������-�� �浹����");
            other.gameObject.SetActive(false);
        }
    }
}
