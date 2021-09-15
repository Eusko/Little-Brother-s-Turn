using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player;
    public GameObject levelGen;
    
    public Transform playerSpawn;
    
    void Start() {
        SpawnLevel();
        GameEvents.instance.onRestartLevel += SpawnLevel;
    }
    
    // spawn in Rabousch
    public void SpawnLevel(){
        player.SetActive(true);
        player.transform.position = playerSpawn.position;

        levelGen.SetActive(true);
    }
}
