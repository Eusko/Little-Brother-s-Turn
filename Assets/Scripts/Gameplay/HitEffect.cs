using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public GameObject sweatDrop;
    Animator dropAnim;
    
    public GameObject canvas;
    DisobeyControl disobeyControl;
    ButtonHandler buttons;
    
    float originalChance;
    bool cowering;
    
    public float obeyDuration;
    float obeyTime;
    
    void Start() {
        disobeyControl = canvas.transform.GetComponent<DisobeyControl>();
        buttons = canvas.transform.GetComponent<ButtonHandler>();
        originalChance = disobeyControl.disobeyChance;
        dropAnim = sweatDrop.transform.GetComponent<Animator>();
        
        GameEvents.instance.onRestartLevel += ResetStates;
    }

    void Update() {
        if(Time.time > obeyTime && cowering){
            disobeyControl.disobeyChance = originalChance;
            disobeyControl.disobeyCounter = 0;
            obeyTime = 0;
            cowering = false;
            
            if(sweatDrop.activeInHierarchy){
                dropAnim.SetTrigger("disappear");
            }
            
            StartCoroutine(Recycle());
        }
    }
    
    public void Hit(){
        if(buttons.canHitBro){
            cowering = true;
            obeyTime = Time.time + obeyDuration;
            disobeyControl.disobeyChance = 0f;
            if(sweatDrop == null){
                Debug.Log("Sweat is null");
            }
            StartCoroutine(SweatSpawn());
            buttons.canHitBro = false;
        }
    }
    
    void ResetStates(){
        disobeyControl.disobeyChance = originalChance;
        sweatDrop.SetActive(false);
    }
    
    IEnumerator Recycle(){
        yield return new WaitForSeconds(.667f);
        sweatDrop.SetActive(false);
        cowering = false;
    }
    
    IEnumerator SweatSpawn(){
        yield return new WaitForSeconds(.333f);
        sweatDrop.SetActive(true);
    }
}
