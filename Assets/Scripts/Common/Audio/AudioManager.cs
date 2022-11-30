using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("References")]
    [NonReorderable] public Sound[] _musicArray;
    [NonReorderable] public Sound[] _sfxArray;
    [SerializeField] Slider _musicVolumeSlider;
    [SerializeField] Slider _sfxVolumeSlider;

    [SerializeField] string _mainThemeSong;

    float _musicVolume;
    float _sfxVolume;

    public float MusicVolume => _musicVolume;
    public float SFXVolume => _sfxVolume;

    public static AudioManager instance;

    private void Awake()
    {
        #region Singleton Pattern
        // Destory if multiple instances of this object is in a scene
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        #endregion

        #region Load Audio Settings
        foreach (Sound song in _musicArray)
        {
            song.source = gameObject.AddComponent<AudioSource>();
            song.source.clip = song.clip;

            song.source.volume = song.volume;
            song.source.pitch = song.pitch;
            song.source.loop = song.loop;

            // Consider changing to something more efficient...
            _musicVolumeSlider.value = song.volume;
            _musicVolume = song.volume;
        }

        foreach (Sound sfx in _sfxArray)
        {
            sfx.source = gameObject.AddComponent<AudioSource>();
            sfx.source.clip = sfx.clip;

            sfx.source.volume = sfx.volume;
            sfx.source.pitch = sfx.pitch;
            sfx.source.loop = sfx.loop;

            _sfxVolumeSlider.value = sfx.volume;
            _sfxVolume = sfx.volume;
        }
        #endregion
    }

    private void Start()
    {
        PlaySong(_mainThemeSong);
    }

    public void PlaySong(string name)
    {
        Sound soundToPlay = Array.Find(_musicArray, sound => sound.name == name);

        if (soundToPlay == null)
        {
            Debug.Log("Sound: " + name + " not found.");
            return;
        }

        soundToPlay.source.Play();
    }

    public void PlaySFX(string name)
    {
        Sound soundToPlay = Array.Find(_sfxArray, sound => sound.name == name);

        if (soundToPlay == null)
        {
            Debug.Log("Sound: " + name + " not found.");
            return;
        }

        soundToPlay.source.Play();
    }

    public void ReassignMusicSlider(Slider newSlider)
    {
        _musicVolumeSlider = newSlider;
    }
    
    public void ReassignSFXSlider(Slider newSlider)
    {
        _sfxVolumeSlider = newSlider;
    }

    public void AdjustMusicVolume()
    {
        foreach (Sound song in _musicArray)
        {
            song.source.volume = _musicVolumeSlider.value;
        }

        _musicVolume = _musicVolumeSlider.value;
    }

    public void AdjustSFXVolume()
    {
        foreach (Sound sfx in _sfxArray)
        {
            sfx.source.volume = _sfxVolumeSlider.value;
        }

        _sfxVolume = _sfxVolumeSlider.value;
    }

    // Code to play sound from this AudioManager script
    // FindObjectOfType<AudioManager>().Play("NameOfSound");
}
