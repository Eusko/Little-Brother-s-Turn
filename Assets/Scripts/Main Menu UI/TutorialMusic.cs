using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMusic : MonoBehaviour
{
    public AudioSource tutorialMusic;
    
    void Start() {
        tutorialMusic.volume = PlayerPrefs.GetFloat("MusicVol");
    }
}
