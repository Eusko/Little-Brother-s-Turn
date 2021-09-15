using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    string Android_ID = "3945055";
    string Apple_ID = "3945054";
    
    [Range(0.0f, 1.0f)]
    public float adPercentage;
    
    bool testMode = false;
    
    void Start() {
        
        //Advertisement.Initialize(Android_ID, testMode);
        Advertisement.Initialize(Apple_ID, testMode);
    }

    public void ShowAd(){
        float num = Random.Range(0.01f, 1.0f);
        if(num < adPercentage){
            ShowInterstitialAd();
        }
    }

    void ShowInterstitialAd(){
        Advertisement.Show();
    }

    void Update() {
        
    }
}
