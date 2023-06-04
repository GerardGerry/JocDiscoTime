using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSound : MonoBehaviour
{
    public void SoundRun()
    {
        NewAudioManager.NewPlaySFX(("newRun"), GetComponent<AudioSource>());
    }

    public void StopSoundRun()
    {
        NewAudioManager.NewPlaySFX(("newRun"), GetComponent<AudioSource>(), false);
    }
}
