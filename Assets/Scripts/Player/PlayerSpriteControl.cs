using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine;

public class PlayerSpriteControl : MonoBehaviour
{
    SpriteResolver srHead;
    SpriteResolver srLArm;
    SpriteResolver srLLeg;
    SpriteResolver srRArm;
    SpriteResolver srRLeg;
    SpriteResolver srTorso;
    
    void Start() {
        GameEvents.instance.onRestartLevel += ResetSprites;
        
        srHead = this.transform.GetChild(1).GetComponent<SpriteResolver>();
        srLArm = this.transform.GetChild(2).GetComponent<SpriteResolver>();
        srLLeg = this.transform.GetChild(3).GetComponent<SpriteResolver>();
        srRArm = this.transform.GetChild(4).GetComponent<SpriteResolver>();
        srRLeg = this.transform.GetChild(5).GetComponent<SpriteResolver>();
        srTorso = this.transform.GetChild(6).GetComponent<SpriteResolver>();
        
    }
    
    public void Die(){
        srHead.SetCategoryAndLabel("Head", "Damaged");
        srHead.ResolveSpriteToSpriteRenderer();
        
        srLArm.SetCategoryAndLabel("LArm", "Damaged");
        srLArm.ResolveSpriteToSpriteRenderer();
        
        srLLeg.SetCategoryAndLabel("LLeg", "Damaged");
        srLLeg.ResolveSpriteToSpriteRenderer();
        
        srRArm.SetCategoryAndLabel("RArm", "Damaged");
        srRArm.ResolveSpriteToSpriteRenderer();
        
        srRLeg.SetCategoryAndLabel("RLeg", "Damaged");
        srRLeg.ResolveSpriteToSpriteRenderer();
        
        srTorso.SetCategoryAndLabel("Torso", "Damaged");
        srTorso.ResolveSpriteToSpriteRenderer();
    }
    
    void ResetSprites(){
        srHead.SetCategoryAndLabel("Head", "Normal");
        srHead.ResolveSpriteToSpriteRenderer();
        
        srLArm.SetCategoryAndLabel("LArm", "Normal");
        srLArm.ResolveSpriteToSpriteRenderer();
        
        srLLeg.SetCategoryAndLabel("LLeg", "Normal");
        srLLeg.ResolveSpriteToSpriteRenderer();
        
        srRArm.SetCategoryAndLabel("RArm", "Normal");
        srRArm.ResolveSpriteToSpriteRenderer();
        
        srRLeg.SetCategoryAndLabel("RLeg", "Normal");
        srRLeg.ResolveSpriteToSpriteRenderer();
        
        srTorso.SetCategoryAndLabel("Torso", "Normal");
        srTorso.ResolveSpriteToSpriteRenderer();
    }
}
