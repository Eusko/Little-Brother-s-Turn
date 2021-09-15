using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    PlayerEffects playerEffects;
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            playerEffects = col.gameObject.GetComponent<PlayerEffects>();
            playerEffects.OnPlayerDamage(1);
        }
    }
}
