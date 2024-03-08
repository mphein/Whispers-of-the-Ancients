using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private EventInstance musicEventInstances;
    private EventDescription musicDescription;

    private float musicVolume;
    private float soundVolume;
    private float fadeOut;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        //initial variable value
        fadeOut = 4;
        musicVolume = 0.5f;
        soundVolume = 0.5f;

        InitializeMusic(AudioEvents.instance.menuMusic);
    }

    private void FixedUpdate()
    {
        SetVolume(soundVolume);

    }

    public void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstances = CreateInstance(musicEventReference);
        musicEventInstances.getDescription(out musicDescription);
        musicEventInstances.start();
    }

    public float GetMusicVolume(){
        return musicVolume;
    }

    public float GetSoundVolume(){
        return soundVolume;
    }

    public void SetVolume(float volume)
    {
        musicEventInstances.setParameterByName("Volume", volume);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void thanos()
    {
        musicEventInstances.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
