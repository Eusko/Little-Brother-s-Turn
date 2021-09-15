using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource musicLooped;
    public Slider gameVolSlider;
    public Slider musicVolSlider;
    
    private float gameVolume;
    
    void Start() {
        musicLooped.PlayDelayed(musicSource.clip.length);
    }

    void Update()  {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVol");
        musicLooped.volume = PlayerPrefs.GetFloat("MusicVol");
    }

    public void SetSliders(){
        gameVolSlider.value = PlayerPrefs.GetFloat("GameVol");
        musicVolSlider.value = PlayerPrefs.GetFloat("MusicVol");
    }

    public void UpdateMusicVolume(float volume){
        PlayerPrefs.SetFloat("MusicVol", volume);
    }
    
    public void UpdateGameVolume(float volume){
        PlayerPrefs.SetFloat("GameVol", volume);
    }
}
