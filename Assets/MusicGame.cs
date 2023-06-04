using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGame : MonoBehaviour
{
    public void PlayMusic1()
    {
        NewAudioManager.NewPlayMusic("music1", GetComponent<AudioSource>());
    }
}
