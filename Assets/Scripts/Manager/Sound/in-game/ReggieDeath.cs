using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReggieDeath : MonoBehaviour
{
    public AudioSource reggieDeathSound;
    
    void Start() {
        reggieDeathSound.volume = PlayerPrefs.GetFloat("GameVol");
    }

    public void PlayDeathSound(){
        reggieDeathSound.Play();
    }
}
