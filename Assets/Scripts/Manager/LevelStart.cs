using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public GameObject LoadingScreen;
    Animator loadingScreenAnim;
    
    public GameObject player;
    public GameObject heartsUI;
    
    void Start() {
        LoadingScreen.SetActive(true);
        loadingScreenAnim = LoadingScreen.GetComponent<Animator>();
        Invoke("FreezeLevel", 0.05f);
    }
    
    public void StartLevel(){
        loadingScreenAnim.SetTrigger("FadeOut");
        player.SetActive(true);
        heartsUI.SetActive(true);
        Invoke("ShowScore", .25f);
    }
    
    void ShowScore(){
        ScoreHandler.instance.StartCounting();
    }
    
    void FreezeLevel(){
        player.SetActive(false);
        heartsUI.SetActive(false);
    }
}
