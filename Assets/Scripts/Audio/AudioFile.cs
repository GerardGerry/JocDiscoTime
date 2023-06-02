using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AudioFile
{
    public AudioName Name;
    public AudioClip Clip;
    [Range (0,1)]
    public float Volume;
}

public enum AudioName
{
    Die,
    Shoot1,
    Shoot2,
    Shoot3,
    Hit,
    Heal,
    Dash,
    Fit,
    Music1,
    Music2,
    Music3
}