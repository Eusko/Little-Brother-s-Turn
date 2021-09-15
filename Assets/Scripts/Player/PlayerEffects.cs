using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public int playerHealth;
    public float invincibleTime = 1f;
    
    Animator animator;
    Player player;
    PlayerSpriteControl spriteControl;
    
    public AudioSource deathSound;
    public AudioSource rabouschHurt;
    public AudioSource gameOverJingle;
    public AudioSource levelMusic;
    
    void Start() {
        animator = transform.GetChild(0).transform.GetComponent<Animator>();
        player = GetComponent<Player>();
        spriteControl = GetComponentInChildren<PlayerSpriteControl>();
        if(spriteControl == null){
            Debug.LogWarning("sprite controller is null");
        }
    }
    
    public void OnPlayerDamage(int damage){
        if(Time.time > invincibleTime){
            
            rabouschHurt.Play();
            
            invincibleTime = 1f;
            playerHealth -= damage;

            OverlayUI.instance.DecreaseHearts(damage);
            invincibleTime += Time.time;
            
            if(playerHealth == 1){
                OverlayUI.instance.ActivateOverlayPulse();
            }
            
            if(playerHealth <= 0){
                Die();
            }
        }
    }
    
    void Die(){
        GameEvents.instance.PlayerDie();
        
        deathSound.Play();
        gameOverJingle.Play();
        levelMusic.Stop();
        
        // play animation
        animator.SetTrigger("Die");
        spriteControl.Die();
        player.StopMovement();
        Invoke("ShowDeathScreen", 1f);

        GroundGenerator.instance.gameObject.SetActive(false);
        
        playerHealth = 3;
    }
    
    void ShowDeathScreen(){
        OverlayUI.instance.ShowDeathScreen();
        this.gameObject.SetActive(false);
    }
}
