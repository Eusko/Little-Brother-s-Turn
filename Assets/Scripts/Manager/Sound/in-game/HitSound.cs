using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioSource hitSound;
    
    void Start() {
        
    }

    public void PlayHitSound(){
        hitSound.Play();
    }
}
