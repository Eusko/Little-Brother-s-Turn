using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechDeactivator : MonoBehaviour
{
    void OnEnable(){
        Invoke("Deactivate", .8f);
    }
    
    public void Deactivate(){
        Destroy(this.gameObject);
    }
}
