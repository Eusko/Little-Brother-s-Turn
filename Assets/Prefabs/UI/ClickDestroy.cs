using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    void OnEnable(){
        Invoke("Delete", .5f);
    }
    
    void Delete(){
        Destroy(this.gameObject);
    }
}
