using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour
{
    GameObject playerObj;
    Player player;
    GroundGenerator generator;
    
    public static Manager instance;
    void Awake(){
        instance = this;
    }
    
    void Start() {
        playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        generator = GetComponentInChildren<GroundGenerator>();
        if(generator == null){
            Debug.LogWarning("ground generator is null");
        }
    }

    void Update()  {
        if(Input.GetKeyDown(KeyCode.R)){
            RestartRGame();
        }
    }
    
    void ReloadScene(){
        SceneManager.LoadScene("GameJam");
    }
    
    void RestartRGame(){
        // resets hearts UI
        GameEvents.instance.RestartLevel();
    }
}
