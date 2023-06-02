using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AudioFile
{
    public AudioName Name;
    public AudioClip Clip;
    public float Volume;
}

public enum AudioName
{
    Die,
    Hit,
    Shit,
    Fit
}