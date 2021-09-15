using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitShoutLimit : MonoBehaviour
{
    public Sprite[] numbers = new Sprite[4];
    
    public GameObject canvas;
    ButtonHandler buttonHandler;
    
    Image numImage;
    Button button;
    
    int uses = 3;
    
    void Awake(){
        numImage = transform.GetChild(0).transform.GetComponent<Image>();
        button = transform.GetComponent<Button>();
        buttonHandler = canvas.transform.GetComponent<ButtonHandler>();
    }
    
    void OnEnable(){
        Reset();
    }
    
    public void Use(){
        if(uses != 0 && buttonHandler.canHitBro){
            uses -= 1;
            numImage.sprite = numbers[uses];
        }
        if(uses == 0){
            button.interactable = false;
        }
    }
    
    public void Reset(){
        uses = 3;
        numImage.sprite = numbers[3];
        button.interactable = true;
    }
}
