using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    public void TakeDamage()
    {
        AudioManager.PlaySFX(AudioName.Hit, GetComponent<AudioSource>());
    }
}
