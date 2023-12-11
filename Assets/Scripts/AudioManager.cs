using UnityEngine;
using Plugins.Audio.Core;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private SourceAudio sourceSounds;
    [SerializeField]
    private SourceAudio sourceMusic;

    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        sourceMusic = GameObject.FindGameObjectWithTag("SourceMusic").GetComponent<SourceAudio>();
        sourceSounds = GameObject.FindGameObjectWithTag("SourceSound").GetComponent<SourceAudio>();

        #region SINGLETON

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        #endregion

        SetVolume();

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source = sourceMusic;
            }
            else
            {
                s.source = sourceSounds;
            }
        }
    }

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source.Loop = s.loop;
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
            else
            {
                s.source.Loop = s.loop;
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }

        PlayMusic("Music");
    }

    public void PlaySound(string name)
    {
        sourceSounds.Play(name);
    }

    public void PlayMusic(string name)
    {
        sourceMusic.Play(name);
    }

    private void SetVolume()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1f);
        }
    }

    public void OffMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
    }

    public void OnMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", 1f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
    }

    public void OffSounds()
    {
        PlayerPrefs.SetFloat("SoundVolume", 0f);

        foreach (Sound s in sounds)
        {
            if (s.name != "Music")
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }
    }

    public void OnSounds()
    {
        PlayerPrefs.SetFloat("SoundVolume", 1f);

        foreach (Sound s in sounds)
        {
            if (s.name != "Music")
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }
    }
}
