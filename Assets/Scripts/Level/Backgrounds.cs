using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    public GameObject[] backgrounds = new GameObject[3];
    
    void Start() {
        ChooseBackground();
        GameEvents.instance.onRestartLevel  += ChooseBackground;
    }
    
    void ChooseBackground(){
        for(int i = 0; i < 3; i++){
            backgrounds[i].SetActive(false);
        }
        
        int rand = Random.Range(0, 3);
        backgrounds[rand].SetActive(true);
    }
}
