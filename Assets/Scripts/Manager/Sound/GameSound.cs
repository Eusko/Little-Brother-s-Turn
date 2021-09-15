using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    public AudioSource[] sfxSources;
    public AudioSource[] musicSources;
    
    void Start() {
        for(int i = 0; i < sfxSources.Length; i++){
            sfxSources[i].volume = PlayerPrefs.GetFloat("GameVol");
        }
        
        for(int i = 0; i < musicSources.Length; i++){
            musicSources[i].volume = PlayerPrefs.GetFloat("MusicVol");
        }
    }

    void Update() {
        
    }
}
