using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneMove : MonoBehaviour
{
    static int playerCurrent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {

        }
    }
}
