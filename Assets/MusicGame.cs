using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGame : MonoBehaviour
{
    public void PlayMusic1()
    {
        AudioManager.PlayMusic(AudioName.Music1, GetComponent<AudioSource>());
    }
    public void PlayMusic2()
    {
        AudioManager.PlayMusic(AudioName.Music2, GetComponent<AudioSource>());
    }
}
