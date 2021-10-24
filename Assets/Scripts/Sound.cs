using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Sound
{

    public string name;
    public AudioClip clip;
    public AudioMixerGroup output;

    [Range(0f, 1f)]
    public float volume;
    

    public bool loop;
    public bool mute;



    [HideInInspector]
    public AudioSource source;
}