using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameVol : MonoBehaviour
{
    public AudioSource[] menuAudio;
    
    void Start() {
        
    }

    void Update() {
        for(int i = 0; i < menuAudio.Length; i++){
            menuAudio[i].volume = PlayerPrefs.GetFloat("GameVol");
        }
        
    }
}
