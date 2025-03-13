using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pick2 : MonoBehaviour
{
    private void Awake()
    {
        if(GameManager.instance.is2222) gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.instance.is2222)
        {
            GameManager.instance.is2222 = true;
            gameObject.SetActive(false);
        }
    }
}