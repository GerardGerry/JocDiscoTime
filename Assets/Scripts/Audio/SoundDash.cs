using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDash : MonoBehaviour
{
    public void PlayDash()
    {
        AudioManager.PlaySFX(AudioName.Dash, GetComponent<AudioSource>());
    }
}
