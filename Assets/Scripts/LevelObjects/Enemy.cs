using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerEffects playerEffects;
    Animator animator;
    BoxCollider2D enemyCollider;
    ScorePopUp score;
    
    SpriteResolver spriteResolverHead;
    SpriteResolver spriteResolverBody;
    
    GameObject destroyPoint;
    Transform destroyTransform;
    
    bool canAttackPlayer = true;
    
    DigbyDeath digbyDeath;
    
    void Start() {
        
        animator = transform.GetComponent<Animator>();
        enemyCollider = transform.GetComponent<BoxCollider2D>();
        score = transform.GetComponent<ScorePopUp>();
        
        digbyDeath = transform.GetComponent<DigbyDeath>();
        
        destroyPoint = GameObject.Find("ResetEnemyTransform");
        destroyTransform = destroyPoint.transform;
        
        GameEvents.instance.onRestartLevel += ResetStates;
        
        if(this.name == "Reggie"){
            spriteResolverBody = this.transform.GetChild(0).GetComponent<SpriteResolver>();
            spriteResolverHead = this.transform.GetChild(2).GetComponent<SpriteResolver>();
        }
    }

    void Update() {
        if(transform.position.x < destroyTransform.position.x) {
            ResetStates();
        }
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player") && canAttackPlayer){
            playerEffects = col.GetComponent<PlayerEffects>();
            playerEffects.OnPlayerDamage(1);
            
            enemyCollider.enabled = false;
        }
    }
    
    public void ResetStates(){
        canAttackPlayer = true;
        enemyCollider.enabled = true;
        animator.SetBool("isDead", false);
        
        if(this.name == "Reggie"){
            spriteResolverBody.SetCategoryAndLabel("Body", "Normal");
            spriteResolverBody.ResolveSpriteToSpriteRenderer();
            
            spriteResolverHead.SetCategoryAndLabel("Head", "Normal");
            spriteResolverHead.ResolveSpriteToSpriteRenderer();
        }
    }
    
    public void Die(){

        canAttackPlayer = false;        
        enemyCollider.enabled = false;
        animator.SetBool("isDead", true);
        score.ShowScore();
        
        if(this.name == "Reggie"){
            
            spriteResolverBody.SetCategoryAndLabel("Body","Dead");
            spriteResolverBody.ResolveSpriteToSpriteRenderer();
            
            spriteResolverHead.SetCategoryAndLabel("Head", "Dead");
            spriteResolverHead.ResolveSpriteToSpriteRenderer();
            
            
        }
        else{
            Debug.Log("go to death sound");
            digbyDeath.PlayDeathSound();
        }
    }
}

