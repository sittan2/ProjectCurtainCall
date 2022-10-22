using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
        
    public void Play(Define.SoundType soundType)
    {
        string path = "Sound/" + soundType;
        AudioClip clip = Resources.Load<AudioClip>(path);
        //m_AudioSource.clip = clip;
        m_AudioSource.PlayOneShot(clip);
    }
}