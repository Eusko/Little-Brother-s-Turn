using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    PlayerInput input;
    SpeechUIHandler speechUI;
    ButtonFades buttonFades;
    DisobeyControl disobey;
    
    public GameObject player;
    Animator playerAnimator;
    public GameObject fist;
    Animator fistAnimator;
    public GameObject brother;
    Animator brotherAnimator;
    public GameObject LevelStart;
    LevelStart levelStart;
    
    public AudioSource pummelSound;
    public AudioSource gameLevelMusic;
    public AudioSource gameOverMusic;
    public AudioSource shoutSound;
    
    [HideInInspector]
    public bool isDelay = true;
    public float minDelay;
    public float maxDelay;
    float inputDelayTime;
    
    // 0 = attack, 1 = jump, 2 = move down
    bool[] canCommand = new bool[3];
    public bool canHitBro = true;
    float hitTime;
    bool hasRestarted;
    
    void Start() {
        Init();
    }

    void Update() {
        if(hitTime < Time.time && !canHitBro){
            canHitBro = true;
        }
    }
    
    public void DelayedAttack() {
        if(canCommand[0]){
            canCommand[0] = false;
            speechUI.ShowSpeech(0);
            if(isDelay){
                inputDelayTime = ChooseDelay();
            }else{
                inputDelayTime = 0.0f;
            }
            bool isDisobey = disobey.DisobeyHandling();
            if(!isDisobey){
                Invoke("Attack", inputDelayTime);
            }else{
                StartCoroutine(Disobey(inputDelayTime));
            }
        }
    }
	
    // these next four functions could be consolidated into one with a for loop
    public void DelayedJump() {
        if(canCommand[1]){
            canCommand[1] = false;
            speechUI.ShowSpeech(1);
            if(isDelay){
                inputDelayTime = ChooseDelay();
            }else{
                inputDelayTime = 0.0f;
            }
            bool isDisobey = disobey.DisobeyHandling();
            if(!isDisobey){
                Invoke("Jump", inputDelayTime);
            }else{
                StartCoroutine(Disobey(inputDelayTime));
            }
        }
    }
	
    public void DelayedMoveDown() {
        if(canCommand[2]){
            canCommand[2] = false;
            speechUI.ShowSpeech(2);
            if(isDelay){
                inputDelayTime = ChooseDelay();
            }else{
                inputDelayTime = 0.0f;
            }
            bool isDisobey = disobey.DisobeyHandling();
            if(!isDisobey){
                Invoke("MoveDown", inputDelayTime);
            }else{
                StartCoroutine(Disobey(inputDelayTime));
            }
        }
    }
    
    public void DelayedStart(){
        speechUI.ShowSpeech(3);
        if(isDelay){
            inputDelayTime = ChooseDelay();
        }else{
            inputDelayTime = 0.0f;
        }
        bool isDisobey = disobey.DisobeyHandling();
        if(!isDisobey){
            Invoke("StartGame", inputDelayTime);
        }else{
            StartCoroutine(Disobey(inputDelayTime));
        }
    }
    
    public void DelayedRestart(){
        if(!hasRestarted){
            hasRestarted = true;
            speechUI.ShowSpeech(4);
            if(isDelay){
                inputDelayTime = ChooseDelay();
            }else{
                inputDelayTime = 0.0f;
            }
            Invoke("Restart", inputDelayTime);
            
        }
    }
    
    public void Hit(){
        if(canHitBro){
            hitTime = 1.39f + Time.time;
            speechUI.ShowSpeech(5);
            fist.SetActive(true);
            fistAnimator.SetTrigger("punch");
            
            brotherAnimator.SetTrigger("punch");
            
            Invoke("fistInactive", .667f);
        }
    }
    
    IEnumerator Disobey(float t){
        yield return new WaitForSeconds(t);
        disobey.Disobey();
        
        for(int i = 0; i < 3; i++){
            canCommand[i] = true;
        }
    }
    
    public void Shout(){
        if(canHitBro){
            hitTime = 1f + Time.time;
            shoutSound.Play();
            speechUI.ShowSpeech(6);
        }
    }
    
    public void RepeatedHit(){
        if(canHitBro){
            pummelSound.Play();
            
            hitTime = 4f + Time.time;
            
            fist.SetActive(true);
            fistAnimator.SetTrigger("pummel");
            
            brotherAnimator.SetTrigger("pummel");
            
            Invoke("fistInactive", 4f);
            canHitBro = false;
        }
    }
    
    float ChooseDelay(){
        float delay = Random.Range(minDelay, maxDelay);
        return delay;
    }
    
    void Attack(){
        ClickUI.instance.ClickAppear();
        input.Attack();
        canCommand[0] = true;
    }
    
    void Jump(){
        ClickUI.instance.ClickAppear();
        input.Jump();
        playerAnimator.SetTrigger("jump");
        canCommand[1] = true;
    }
    
    void MoveDown(){
        ClickUI.instance.ClickAppear();
        input.MoveDown();
        canCommand[2] = true;
    }
    
    void StartGame(){
        gameLevelMusic.Play();
        
        levelStart.StartLevel();
        ClickUI.instance.ClickAppear();
        buttonFades.LateStart();
        for(int i = 0; i < 3; i++){
            canCommand[i] = true;
        }
    }
    
    void Restart(){
        gameLevelMusic.Play();
        gameOverMusic.Stop();
        
        ClickUI.instance.ClickAppear();
        buttonFades.LateRestart();
        hasRestarted = false;
    }
    
    void fistInactive(){
        fist.SetActive(false);
    }
    
    void Init(){
        input = GameObject.Find("Player").transform.GetComponent<PlayerInput>();
        playerAnimator = player.transform.GetComponent<Animator>();
        fistAnimator = fist.GetComponent<Animator>();
        brotherAnimator = brother.GetComponent<Animator>();
        speechUI = this.transform.GetComponent<SpeechUIHandler>();
        levelStart = LevelStart.GetComponent<LevelStart>();
        buttonFades = this.transform.GetComponent<ButtonFades>();
        disobey = this.transform.GetComponent<DisobeyControl>();
    }
}
