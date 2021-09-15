using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {
    
    #region Singleton
    public static GameEvents instance;

    private void Awake() {
        instance = this;
    }
    #endregion

    // could go in its own script for better organization
    #region Animation Events
    public event Action onLandingTrigger;
    public void LandingTrigger() {
        if(onLandingTrigger != null) {
            onLandingTrigger();
        }
    }

    public event Action onCrouchingTrigger;
    public void CrouchingTrigger() {
        if (onCrouchingTrigger != null) {
            onCrouchingTrigger();
        }
    }

    public event Action onJumpAscendTrigger;
    public void JumpAscendTrigger() {
        if(onJumpAscendTrigger != null) {
            onJumpAscendTrigger();
        }
    }

    public event Action onFallingTrigger;
    public void FallingTrigger() {
        if (onFallingTrigger != null) {
            onFallingTrigger();
        }
    }

    public event Action onGroundedTrigger;
    public void GroundedTrigger() {
        if (onGroundedTrigger != null) {
            onGroundedTrigger();
        }
    }

    public event Action onStandUpTrigger;
    public void StandUpTrigger() {
        if (onStandUpTrigger != null) {
            onStandUpTrigger();
        }
    }

    public event Action onLocomotionTrigger;
    public void LocomotionTrigger() {
        if (onLocomotionTrigger != null) {
            onLocomotionTrigger();
        }
    }
#endregion

    public event Action onTileInactive;
    public void TileInactive() {
        if(onTileInactive != null) {
            onTileInactive();
            Debug.Log("game event tile");
        }
    }
    
    public event Action onRestartLevel;
    public void RestartLevel(){
        if(onRestartLevel != null){
            onRestartLevel();
        }
    }
    
    public event Action onPlayerDie;
    public void PlayerDie(){
        if(onPlayerDie != null){
            onPlayerDie();
        }
    }
}
