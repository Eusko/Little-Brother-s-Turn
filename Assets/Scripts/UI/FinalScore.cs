using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public string layerToPushTo;
    
    void OnEnable(){
        GetComponent<Renderer>().sortingLayerName = layerToPushTo;
    }
}
