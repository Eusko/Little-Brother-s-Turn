using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopUp : MonoBehaviour
{
    public Transform popupTransform;
    public GameObject scorePrefab;
    public int scoreAmount;
    
    public void ShowScore(){
        Instantiate(scorePrefab, popupTransform);
        ScoreHandler.instance.AddScore(scoreAmount);
    }
}
