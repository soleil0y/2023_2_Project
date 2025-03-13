using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActive : MonoBehaviour
{
    public GameObject flashLight;
    private LightRay lightRay;

    void Update()
    {
        if (GameManager.instance.isPickedUp && Input.GetMouseButtonDown(0))
        {
            flashLight.SetActive(true);
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            flashLight.SetActive(false); 
        }
        //e대충활성화-비활성화
        //한 다음에 허ㅏㄹ성화:레이 ㄱ

        if (flashLight.activeSelf)
        {
            lightRay = GetComponentInChildren<LightRay>();
            lightRay.Ray();
        }
    }
}
