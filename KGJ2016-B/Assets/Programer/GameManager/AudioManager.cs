using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager>
{
    AudioSource audioSource;
    AudioSource loopAudioSource;

    [SerializeField]
    List<AudioClip> clipList = new List<AudioClip>();

    void Start()
    {
        AudioSource[] temp = GetComponents<AudioSource>();

        audioSource = temp[0];
        loopAudioSource = temp[1];
    }

    void OnDestroy()
    {
        loopAudioSource.Stop();
        Instance = null;
    }

    public void Play(string clipName)
    {
        loopAudioSource.clip = GetAudioClip(clipName);
        loopAudioSource.Play();
    }

    public void PlayOneShot(string clipName, float volume = 1.0f)
    {
        audioSource.PlayOneShot(GetAudioClip(clipName), volume);
    }

    AudioClip GetAudioClip(string clipName)
    {
        AudioClip clip = clipList.Find(n => n.name == clipName);

        if (clip != null) return clip;

        clip = Resources.Load<AudioClip>(clipName);

        if (clip != null)
        {
            clipList.Add(clip);
            return clip;
        }

        clip = Resources.Load<AudioClip>("Audios/" + clipName);

        if (clip != null)
        {
            clipList.Add(clip);
            return clip;
        }

        return null;
    }
}
