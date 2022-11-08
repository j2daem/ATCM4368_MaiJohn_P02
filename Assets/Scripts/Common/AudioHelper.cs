using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public static AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        // Create
        GameObject audioObject = new GameObject("Audio2D");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Configure
        audioSource.clip = clip;
        audioSource.volume = volume;

        // Activate
        audioSource.Play();
        Object.Destroy(audioSource, clip.length);
        Object.Destroy(audioObject, volume);

        // Return in case other things need it
        return audioSource;
    }
}
