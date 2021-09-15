using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioSource menuOpen;
    public AudioSource menuClose;
    
    public void MenuOpen(){
        Debug.Log("menu open");
        menuOpen.Play();
    }
    
    public void MenuClose(){
        Debug.Log("menu close");
        menuClose.Play();
    }
    
    void Update(){
    }
}
