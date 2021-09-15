using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource gameMusic;
    
    void Start() {
        
    }

    public void PlayGameMusic(){
        gameMusic.Play();
    }

    void Update() {
        
    }
}
