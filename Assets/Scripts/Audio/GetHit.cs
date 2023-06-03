using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    public void TakeDamage()
    {
        NewAudioManager.NewPlaySFX(("newHurt"), GetComponent<AudioSource>());
    }
}
