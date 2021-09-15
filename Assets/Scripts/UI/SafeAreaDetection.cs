using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaDetection : MonoBehaviour
{
    public delegate void SafeAreaChanged(Rect safeArea);
    public static event SafeAreaChanged OnSafeAreaChanged;
    
    private Rect safeArea;
    
    void Awake() {
        safeArea = Screen.safeArea;
    }

    void Update() {
        if(safeArea != Screen.safeArea){
            safeArea = Screen.safeArea;
            OnSafeAreaChanged?.Invoke(safeArea);
        }
    }
}
