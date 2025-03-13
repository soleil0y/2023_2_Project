using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2SceneMgr : MonoBehaviour
{
    public GameObject disableObj;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance != null && GameManager.instance.is2222)
        {
            disableObj.SetActive(false);
        }
    }
}
