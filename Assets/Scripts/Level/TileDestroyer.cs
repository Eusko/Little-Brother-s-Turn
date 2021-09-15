using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    GameObject destroyPoint;
    Transform destroyTransform;

    void Start() {
        destroyPoint = GameObject.Find("DestroyTransform");
        destroyTransform = destroyPoint.transform;
        GameEvents.instance.onRestartLevel += SetInactive;
    }

    void Update() {
        if(transform.position.x < destroyTransform.position.x) {
            Invoke("SetInactive", .1f);
        }
    }
    
    // could use a coroutine here instead
    void SetInactive(){
        this.gameObject.SetActive(false);
    }
}
