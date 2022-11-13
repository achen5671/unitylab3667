using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // singleton
    public static SoundManager instance {get; private set;}
    private AudioSource source;

    private void Awake() {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    void Start() {
        // Let sound play when switching scene
        // Without this: Audio will get cut off when switching between scenes (balloon pop)
        DontDestroyOnLoad( gameObject );
    }

    public void PlaySound(AudioClip _sound) {
        source.PlayOneShot(_sound);
    }
}
