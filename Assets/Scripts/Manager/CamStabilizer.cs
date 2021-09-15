using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStabilizer : MonoBehaviour
{
    float camPosY;
    Vector3 pos;
    
    void Start() {
        camPosY = transform.position.y;
    }

    void Update() {
        pos = transform.position;
        transform.position = new Vector3(pos.x, camPosY, pos.z);
    }
}
