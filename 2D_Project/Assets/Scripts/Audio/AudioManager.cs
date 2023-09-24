using System.Collections.Generic;
using UnityEngine;


public enum AudioType
{
    MainTheme,
    Beep, 
    Fall,
    Interact,
    Portal
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _mainThemeSource;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _audioClips;

    public void Play(AudioType type)
    {
        _audioSource.PlayOneShot(_audioClips.Find(x => x.name == type.ToString()));
    }

    public void Restart()
    {
        _mainThemeSource.Play();
    }
}
