using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private AudioSource _musicSource;

    [SerializeField]
    private AudioSource _sfxSource;

    public AudioFile[] allFiles;

    [SerializeField]
    float Global_SFX_Volume;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static void PlayerSFX(AudioName name, AudioSource orgSource = null)
    {
        Instance._PlaySFX(name, orgSource);
    }

    public void _PlaySFX(AudioName name, AudioSource orgSource = null)
    {
        var source = orgSource != null ? orgSource : _sfxSource;
        AudioFile file = GetFileByName(name);
        if(file == null)
        {
            return;
        }
        source.clip = file.Clip;
        source.volume = file.Volume * Global_SFX_Volume;
        source.Play();
    }

    AudioFile GetFileByName(AudioName name)
    {
        //for(int i = 0; i < allFiles.Length; i++)
        //{
        //    if(allFiles[i].Name == name)
        //    {
        //        return allFiles[i];
        //    }
        //    return null;
        //    }

        return allFiles.First(x => x.Name == name);

    }


}
