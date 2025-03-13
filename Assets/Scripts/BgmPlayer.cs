using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlayer : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;

    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");

        if (BackgroundMusic != null)
        {
            backmusic = BackgroundMusic.GetComponent<AudioSource>(); 

            if (backmusic != null && !backmusic.isPlaying)
            {
                backmusic.Play();
                DontDestroyOnLoad(BackgroundMusic);
            }
        }
    }
}
