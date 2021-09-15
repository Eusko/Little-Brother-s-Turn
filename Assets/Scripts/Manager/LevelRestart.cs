using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestart : MonoBehaviour
{
    Transform initTransform;
    
    void Start() {
        GameEvents.instance.onRestartLevel += LevelReload;
        initTransform = this.transform;
    }
    
    void LevelReload(){
        this.transform.position = initTransform.position;
    }
}
