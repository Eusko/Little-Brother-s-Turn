using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : MonoBehaviour
{
    Transform initTransform;
    
    void Start() {
        GameEvents.instance.onRestartLevel += PlayerReload;
        initTransform = this.transform;
    }

    void PlayerReload(){
        this.transform.position = initTransform.position + new Vector3(0.0f, 0.5f, 0.0f);
    }
}
