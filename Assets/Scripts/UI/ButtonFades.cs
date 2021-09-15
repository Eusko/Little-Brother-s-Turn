using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFades : MonoBehaviour
{
    public GameObject startButton;
    public GameObject GameButtons;
    public GameObject restartButtons;
    
    Animator startAnim;
    Animator GameAnim;
    Animator restartAnim;
    
    void Start() {
        startAnim = startButton.GetComponent<Animator>();
        GameAnim = GameButtons.GetComponent<Animator>();
        restartAnim = restartButtons.GetComponent<Animator>();
        
        GameEvents.instance.onPlayerDie += onDie;
    }
    
    // button activation handling
    public void onStartClick(){
        startAnim.SetTrigger("FadeOut");
        StartCoroutine(Disable(0));
    }
    
    public void onDie(){
        GameAnim.SetTrigger("FadeOut");
        StartCoroutine(Disable(1));
        
        StartCoroutine(ActivateRestartButtons(0.75f));
    }
    
    public void onRestart(){
        StartCoroutine(Disable(2));
        restartAnim.SetTrigger("FadeOut");
    }
    
    public void LateStart(){
        GameButtons.SetActive(true);
    }
    
    public void LateRestart(){
        GameEvents.instance.RestartLevel();
        GameButtons.SetActive(true);
    }
    
    IEnumerator Disable(int i){
        yield return new WaitForSeconds(0.5f);
        if(i == 0){
            startButton.SetActive(false);
        }
        if(i == 1){
            GameButtons.SetActive(false);
        }
        if(i == 2){
            restartButtons.SetActive(false);
        }
    }
    
    IEnumerator ActivateRestartButtons(float i){
        yield return new WaitForSeconds(i);
        restartButtons.SetActive(true);
    }
}
