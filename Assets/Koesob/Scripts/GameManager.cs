using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public AudioSource bgmPlayer;

    public void Init()
    {
        Debug.Log("GameManager Init");

        bgmPlayer = GameObject.Find("BGM Player").GetComponent<AudioSource>();

        Debug.Log(bgmPlayer);
    }
}
