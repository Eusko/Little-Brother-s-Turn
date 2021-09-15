using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechUIHandler : MonoBehaviour
{
    public GameObject[] speech = new GameObject[7];
    GameObject currentSpeech;
    public Transform speechLoc;
    
    public void ShowSpeech(int i){
        
        if(currentSpeech == null){
            currentSpeech = Instantiate(speech[i], speechLoc);
        }else{
            SpeechDeactivator deactivator = currentSpeech.GetComponent<SpeechDeactivator>();
            deactivator.Deactivate();
            currentSpeech = Instantiate(speech[i]);
        }
    }
}
