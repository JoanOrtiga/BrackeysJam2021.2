using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum soundType
{
    SFX,
    music,
    global
}

public class MusicManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerGroup musicMixer;
    public AudioMixerGroup sfxMixer;

    public AudioClip[] musicClips;

    private AudioSource music;
    private AudioLowPassFilter passFilter;

    public float sfxVolume = 0.5f, musicVolume = 0.5f, globalVolume = 0.5f; //This is needed to initialitzate the value of the sliders
    private int currentMusic = 1;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        ChangeVolume(sfxVolume, soundType.SFX);
        ChangeVolume(musicVolume, soundType.music);
        ChangeVolume(globalVolume, soundType.global);

        passFilter = GetComponent<AudioLowPassFilter>();
    }
    private void Start()
    {
        music = GetComponent<AudioSource>();
        music.outputAudioMixerGroup = musicMixer;
        music.loop = true;
        music.clip = musicClips[0];
        music.Play();
    }

    public void ChangeVolume(float value, soundType s)
    {
        switch (s)
        {
            case soundType.SFX:
                sfxVolume = value;
                SetVolume("SFXVol", value);
                break;
            case soundType.music:
                musicVolume = value;
                SetVolume("MusicVol", value);
                break;
        }
    }
    private void SetVolume(string parameter, float value)
    {
        if (value < 0.1f)
        {
            mixer.SetFloat(parameter, -80); //avoids errors that when 0 log10 is 0 and should be -80 to mute.
            return;
        }

        if (mixer)
            mixer.SetFloat(parameter, Mathf.Log10(value) * 20);
    }

    public void ApplyFilter()
    {
        if (passFilter)
            passFilter.enabled = true;
    }
    public void StopFilter()
    {
        if (passFilter)
            passFilter.enabled = false;
    }
    private void OnLevelWasLoaded(int level)
    {
        StopFilter();
        if (level == 0)
        {
            if (music)
            {
                music.clip = musicClips[0];
                music.Play();
            }
        }
        else
        {
            music.clip = musicClips[1];
            music.Play();
        }
    }
    public void StartBattle()
    {
        currentMusic = (currentMusic % (musicClips.Length - 1))+1 ;
        music.clip = musicClips[currentMusic];
        music.Play();
    }
}
