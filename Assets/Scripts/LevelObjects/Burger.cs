using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    Animator animator;
    public int scoreAmt;
    public AudioSource burgerSound;
    ScorePopUp scorePopUp;
    
    void Start() {
        animator = transform.GetChild(0).transform.GetComponent<Animator>();
        scorePopUp = transform.GetComponent<ScorePopUp>();
        
        burgerSound.volume = PlayerPrefs.GetFloat("GameVol");
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            burgerSound.Play();
            
            ScoreHandler.instance.AddScore(scoreAmt);
            animator.SetTrigger("get");
            scorePopUp.ShowScore();
            StartCoroutine(GetBurger());
        }
    }
    
    IEnumerator GetBurger(){
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }
}
