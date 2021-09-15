using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public GameObject splash1;
    public GameObject splash2;
    
    public float waitTime;
    float timer;
    
    void Start() {
        splash1.SetActive(true);
        timer = Time.time;
    }

    void Update() {
        if(Time.time > timer + waitTime){
            Skip();
            timer = Time.time;
        }
        
        if(Input.GetMouseButtonDown(0)){
            Skip();
        }
    }
    
    public void Skip(){
        if(splash2.activeInHierarchy){
            SceneManager.LoadScene("Main Menu");
        }else{
            splash2.SetActive(true);
        }
    }
}
