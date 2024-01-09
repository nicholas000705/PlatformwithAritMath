using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] backgroundMusic, effectMusic;
    public AudioSource backgroundMusicSource, effectMusicSource;
    private const string BackgroundMusicVolumeKey = "BackgroundMusicVolume";
    private const string BackgroundMusicMuteKey = "BackgroundMusicMute";
    private const string EffectMusicVolumeKey = "EffectMusicVolume";
    private const string EffectMusicMuteKey = "EffectMusicMute";

    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Load sound settings from user 
        float savedBackgroundVolume = PlayerPrefs.GetFloat(BackgroundMusicVolumeKey, 0.3f);
        bool savedBackgroundMute = PlayerPrefs.GetInt(BackgroundMusicMuteKey, 0) == 1;
        float savedEffectVolume = PlayerPrefs.GetFloat(EffectMusicVolumeKey, 0.4f);
        bool savedEffectMute = PlayerPrefs.GetInt(EffectMusicMuteKey, 0) == 1;

        backgroundMusicSource.volume = savedBackgroundVolume;
        backgroundMusicSource.mute = savedBackgroundMute;
        effectMusicSource.volume = savedEffectVolume;
        effectMusicSource.mute = savedEffectMute;
    }

    public void PlayBackgroundMusic(string musicName)
    {
        Sound sound = Array.Find(backgroundMusic, x => x.name == musicName);

        if(sound != null)
        {
            backgroundMusicSource.clip = sound.audioClip;
            backgroundMusicSource.Play();
        }
    }

    public void PlayEffectSound(string musicName)
    {
        Sound sound = Array.Find(effectMusic, x => x.name == musicName);

        if (sound != null)
        {
            effectMusicSource.clip = sound.audioClip;
            effectMusicSource.Play();
        }
    }

    public void ToggleBackgroundMusic()
    {
        backgroundMusicSource.mute = !backgroundMusicSource.mute;
        PlayEffectSound("Toggle");

        // Save background music mute state to PlayerPrefs
        PlayerPrefs.SetInt(BackgroundMusicMuteKey, backgroundMusicSource.mute ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ToggleEffectSound()
    {
        effectMusicSource.mute = !effectMusicSource.mute;
        PlayEffectSound("Toggle");

        // Save effect sound mute state to PlayerPrefs
        PlayerPrefs.SetInt(EffectMusicMuteKey, effectMusicSource.mute ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void BackgroundMusicSettings(float volume)
    {
        backgroundMusicSource.volume = volume;
        PlayEffectSound("Toggle");

        // Save background music volume to PlayerPrefs
        PlayerPrefs.SetFloat(BackgroundMusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void EffectSoundVolumeSettings(float volume)
    {
        effectMusicSource.volume = volume;
        PlayEffectSound("Toggle");

        // Save effect music volume to PlayerPrefs
        PlayerPrefs.SetFloat(EffectMusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    void Start()
    {
        PlayBackgroundMusic("Main Menu Theme");
    }
}
