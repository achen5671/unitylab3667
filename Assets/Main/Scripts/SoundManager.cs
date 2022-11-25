using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    // singleton
    public static SoundManager instance {get; private set;}
    private AudioSource source;

    // See: https://www.youtube.com/watch?v=yWCHaTwVblk for volume slider
    [SerializeField] Slider volumeSlider;
    private void Awake() {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    void Start() {
        // Let sound play when switching scene
        // Without this: Audio will get cut off when switching between scenes (balloon pop)
        DontDestroyOnLoad( gameObject );
        if (!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }else {
            Load();
        }
    }

    public void PlaySound(AudioClip _sound) {
        source.PlayOneShot(_sound);
    }
    
    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load() {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
