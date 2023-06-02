using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioFile[] allFilesSFX;
    public AudioFile[] allFileMusic;

    [SerializeField]
    public AudioSource _musicSource;
    [SerializeField]
    public AudioSource _sfxSource;

    [SerializeField]
    float Global_SFX_Volume;
    [SerializeField]
    float Global_Music_Volume;

    MusicGame _music1;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            _music1 = GetComponentInChildren<MusicGame>();
            Instance = this;
            _music1.PlayMusic1();
        }
        else
        {
            Destroy(this);
        }
    }

    public static void PlayMusic(AudioName name, AudioSource orgSource = null)
    {
        Instance._PlayMusic(name, orgSource);
    }

    public static void PlaySFX(AudioName name, AudioSource orgSource = null)
    {
        Instance._PlaySFX(name, orgSource);
    }

    public void _PlaySFX(AudioName name, AudioSource orgSource = null)
    {
        var source = orgSource != null ? orgSource : _sfxSource;
        AudioFile file = GetFileByName(name);
        if (file == null)
        {
            return;
        }
        source.clip = file.Clip;
        source.volume = file.Volume * Global_SFX_Volume;
        source.Play();
    }

    public void _PlayMusic(AudioName name, AudioSource orgSource = null)
    {
        var source = orgSource != null ? orgSource : _musicSource;
        AudioFile file = GetFileByNameMusic(name);
        if (file == null)
        {
            return;
        }
        source.clip = file.Clip;
        source.volume = file.Volume * Global_Music_Volume;
        source.Play();
    }

    AudioFile GetFileByName(AudioName name)
    {
        return allFilesSFX.First(x => x.Name == name);
    }
    AudioFile GetFileByNameMusic(AudioName name)
    {
        return allFileMusic.First(x => x.Name == name);
    }


}
