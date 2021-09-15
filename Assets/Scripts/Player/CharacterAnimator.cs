using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = 0.05f;

    public Player player;
    public Animator animator;

    void Start() {
        SetupEvents();
    }

    void Update() {
        SetSpeedPercent();
    }

    public void OnGrounded() {
        animator.SetBool("isGrounded", true);
        animator.SetBool("isFalling", false);

        if (player.isCrouchInput) {
            OnCrouching();
        }
    }

    public void OnLanding() {
        animator.SetTrigger("land");
        animator.SetBool("isFalling", false);
    }

    public void OnCrouching() {
        animator.SetBool("isCrouching", true);
    }

    public void OnJumpAscend() {
        animator.SetBool("isCrouching", false);
        animator.SetBool("isGrounded", false);
    }

    public void OnFalling() {
        animator.SetBool("isFalling", true);
        animator.SetBool("isGrounded", false);
    }

    public void OnLocomotion() {
        animator.SetBool("isCrouching", false);
    }

    void SetSpeedPercent() {
        float speedPercent = Mathf.Abs(player.velocity.x / player.moveSpeedActual);
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
    }

    void SetupEvents() {
        GameEvents.instance.onLandingTrigger += OnLanding;
        GameEvents.instance.onCrouchingTrigger += OnCrouching;
        GameEvents.instance.onJumpAscendTrigger += OnJumpAscend;
        GameEvents.instance.onFallingTrigger += OnFalling;
        GameEvents.instance.onGroundedTrigger += OnGrounded;
        GameEvents.instance.onLocomotionTrigger += OnLocomotion;
    }
}
