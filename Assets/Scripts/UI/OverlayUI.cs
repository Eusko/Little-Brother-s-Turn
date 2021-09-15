using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayUI : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject[] brokenHearts;
    
    public GameObject hurtOverlay;
    Animator hurtOverlayAnimator;
    
    public GameObject gameOverScreen;
    
    #region Singleton
    public static OverlayUI instance;
    
    void Awake(){
        instance = this;
        
    }
    #endregion
    
    void Start(){
        hurtOverlayAnimator = hurtOverlay.GetComponent<Animator>();
        Reset();
        GameEvents.instance.onRestartLevel += Reset;
    }
    
    public void DecreaseHearts(int damage){
        for(int j = 0; j < damage; j++){
            for(int i = 0; i < hearts.Length; i++){
                if(hearts[i].activeInHierarchy){
                    hearts[i].SetActive(false);
                    brokenHearts[i].SetActive(true);
                    break;
                }
            }
        }
        hurtOverlay.SetActive(true);
        Invoke("HurtOverlayInactive", .5f);
    }
    
    public void ActivateOverlayPulse(){
        Debug.Log("activate pulse");
        hurtOverlay.SetActive(true);
        hurtOverlayAnimator.SetTrigger("hurtTrigger");
    }
    
    void HurtOverlayInactive(){
        hurtOverlay.SetActive(false);
    }
    
    public void ShowDeathScreen(){
        gameOverScreen.SetActive(true);
    }
    
    public void Reset(){
        for(int i = 0; i < hearts.Length; i++){
            hearts[i].SetActive(true);
            brokenHearts[i].SetActive(false);
        }
        hurtOverlay.SetActive(false);
        gameOverScreen.SetActive(false);
    }
}
