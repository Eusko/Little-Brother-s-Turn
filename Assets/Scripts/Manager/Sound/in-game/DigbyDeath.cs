using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigbyDeath : MonoBehaviour
{
    public AudioSource digbyDeathSound;
    
    void Start() {
        digbyDeathSound.volume = PlayerPrefs.GetFloat("GameVol");
    }

    public void PlayDeathSound(){
        Debug.Log("digby death");
        digbyDeathSound.Play();
        Debug.Log(digbyDeathSound.volume);
    }
}
