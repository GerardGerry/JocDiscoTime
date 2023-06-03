using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewAudioManager : MonoBehaviour
{
    public static NewAudioManager Instance;

    public NewAudioFile[] allFilesSFX;
    public NewAudioFile[] allFileMusic;

    public AudioSource _musicSource;
    public AudioSource _sfxSource;

    [SerializeField]
    float Global_SFX_Volume;
    [SerializeField]
    float Global_Music_Volume;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static void NewPlayMusic(string name)
    {
        Instance._PlayMusic(name);
    }

    public static void NewPlaySFX(string name, AudioSource source = null)
    {
        Instance._PlaySFX(name, source);
    }

    private void _PlaySFX(string soundName, AudioSource source = null)
    {
        var newsource = source != null ? source : _sfxSource;
        var file = GetFileByNameSFX(soundName);

        if(file != null)
        {
            var clip = file.Clip;
            newsource.volume = file.Volume * Global_SFX_Volume;
            newsource.clip = clip;
            newsource.Play();
        }
    }

    private void _PlayMusic(string soundName, AudioSource orgSource = null)
    {
        var file = GetFileByNameMusic(soundName);

        if(file != null)
        {
            var clip = file.Clip;
            _musicSource.volume = file.Volume * Global_Music_Volume;
            if(clip != null)
            {
                _musicSource.clip = clip;
                _musicSource.Play();
            }
        }
    }

    private NewAudioFile GetFileByNameSFX(string soundName)
    {
        var file = allFilesSFX.First(x => x.Name == soundName);
        if(file != null)
        {
            return file;
        }
        return null;
    }
    private NewAudioFile GetFileByNameMusic(string soundName)
    {
        return allFileMusic.First(x => x.Name == name);
    }


}

