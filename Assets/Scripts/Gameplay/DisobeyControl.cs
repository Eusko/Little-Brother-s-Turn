using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisobeyControl : MonoBehaviour
{
    public GameObject noObj;
    public AudioSource disobeySound;
    
    public float disobeyChance;
    int disobeyFrequency;
    public int disobeyCounter;
    
    void Start(){
        GameEvents.instance.onRestartLevel += ResetValues;
        disobeyFrequency = Random.Range(5, 9);
    }
    
    // controls when brother disobeys based on when he last disobeyed
    public bool DisobeyHandling(){
        disobeyCounter++;
        if(disobeyCounter == disobeyFrequency){
            float rand = Random.Range(0.0f, 1.0f);
            if(rand > 0 && rand <= disobeyChance){
                ResetValues();
                return true;
            }
        }
        return false;
    }
    
    public void Disobey(){
        disobeySound.Play();
        noObj.SetActive(true);
        StartCoroutine(Recycle());
    }
    
    IEnumerator Recycle(){
        yield return new WaitForSeconds(.667f);
        noObj.SetActive(false);
    }
    
    void ResetValues(){
        disobeyCounter = 0;
        disobeyFrequency = Random.Range(5, 9);
    }
}
