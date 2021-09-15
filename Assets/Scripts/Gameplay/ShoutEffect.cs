using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutEffect : MonoBehaviour
{
    public GameObject angry;
    public GameObject shoutObj;
    public GameObject canvas;
    ButtonHandler buttons;
    
    Animator angryAnim;
    
    bool shouting;
    public float ShoutDuration;
    float ShoutTime;
    
    void Start() {
        buttons = canvas.transform.GetComponent<ButtonHandler>();
        angryAnim = angry.transform.GetComponent<Animator>();
    }
    
    void Update(){
        if(Time.time > ShoutTime && shouting){
            ShoutTime = 0;
            shouting = false;
            buttons.isDelay = true;
            
            angryAnim.SetTrigger("vanish");
            StartCoroutine(DespawnAngry());
        }
    }
    
    public void Shout(){
        if(buttons.canHitBro){
            shoutObj.SetActive(true);
            buttons.isDelay = false;
            
            shouting = true;
            ShoutTime = Time.time + ShoutDuration;
            
            StartCoroutine(SpawnAngryObj());
        }
        buttons.canHitBro = false;
        StartCoroutine(Recycle());
    }
    
    IEnumerator SpawnAngryObj(){
        yield return new WaitForSeconds(.3f);
        angry.SetActive(true);
    }
    
    IEnumerator Recycle(){
        yield return new WaitForSeconds(.667f);
        shoutObj.SetActive(false);
    }
    
    IEnumerator DespawnAngry(){
        yield return new WaitForSeconds(.334f);
        angry.SetActive(false);
    }
}
