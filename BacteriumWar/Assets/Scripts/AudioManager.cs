using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
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

        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();

            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;

            sound.audioSource.loop = sound.loop;
        }
    }

    private void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound soundToPlay = Array.Find(sounds, sound => sound.name == name);

        if (soundToPlay == null)
        {
            Debug.LogWarning(name + " not found");
            return;
        }

        soundToPlay.audioSource.Play();
    }
}
