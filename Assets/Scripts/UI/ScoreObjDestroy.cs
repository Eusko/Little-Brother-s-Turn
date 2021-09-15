using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObjDestroy : MonoBehaviour
{
    void Start() {
        StartCoroutine(Destroy());
    }
    
    IEnumerator Destroy(){
        yield return new WaitForSeconds(.667f);
        Destroy(this.gameObject);
    }
}
