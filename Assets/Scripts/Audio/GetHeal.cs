using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeal : MonoBehaviour
{
    public void Heal()
    {
        AudioManager.PlaySFX(AudioName.Heal, GetComponent<AudioSource>());
    }
}