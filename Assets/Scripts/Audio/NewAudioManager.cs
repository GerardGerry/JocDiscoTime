using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Audio;
using UnityEngine;

public class NewAudioManager : MonoBehaviour
{
    public static NewAudioManager Instance;

    public NewAudioFile[] allFilesSFX;
    public NewAudioFile[] allFileMusic;

    public AudioSource _musicSource;
    public AudioSource _sfxSource;

    public AudioMixer audioMixer;
    MusicGame musicGame;

    [SerializeField]
    float Global_SFX_Volume;
    [SerializeField]
    float Global_Music_Volume;

    // Start is called before the first frame update
    void Awake()
    {
        musicGame = GetComponentInChildren<MusicGame>();
        if (Instance == null)
        {
            Instance = this;
            musicGame.PlayMusic1();
        }
        else
        {
            Destroy(this);
        }
    }

    public static void NewPlayMusic(string name, AudioSource source = null, bool play = true)
    {
        Instance._PlayMusic(name, source, play);
    }

    public static void NewPlaySFX(string name, AudioSource source = null, bool play = true)
    {
        Instance._PlaySFX(name, source, play);
    }

    private void _PlaySFX(string soundName, AudioSource source = null, bool play = true)
    {
        var newsource = source != null ? source : _sfxSource;
        var file = GetFileByNameSFX(soundName);

        if(file != null)
        {
            var clip = file.Clip;
            newsource.clip = clip;
            newsource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Sfx")[0];
            newsource.volume = file.Volume * Global_SFX_Volume;
            if(play == true)
            {
                newsource.Play();
            }
            else
            {
                newsource.Stop();
            }

        }
    }

    private void _PlayMusic(string soundName, AudioSource source = null, bool play = true)
    {
        var newsource = source != null ? source : _musicSource;
        var file = GetFileByNameMusic(soundName);

        if(file != null)
        {
            var clip = file.Clip;
            newsource.clip = clip;
            newsource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Music")[0]; ;
            newsource.volume = file.Volume * Global_Music_Volume;
            if (play == true)
            {
                newsource.Play();
            }
            else
            {
                newsource.Stop();
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
        var file = allFileMusic.FirstOrDefault(x => x.Name == soundName);
        if (file != null)
        {
            return file;
        }
        return null;
    }


}

