using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDash : MonoBehaviour
{
    public void PlayDash()
    {
        NewAudioManager.NewPlaySFX("newDash", GetComponent<AudioSource>());
    }
}
