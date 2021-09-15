using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

// much of the code written in this script by Sebastian Lague
// https://www.youtube.com/user/Cercopithecan

// previously used in my project Don't Be Slow, so there's a lot of 
// extraneous and unnecessary code that needs to be cleaned out

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

	// moving and jumping
	[HideInInspector]
	public bool canInputMovement = true;
	public bool isCrouchInput;
	
	public float moveSpeedTarget = 8f;
	public float moveSpeedActual = 8f;
	public float crouchMoveSpeed = 3.5f;
	
	public float maxJumpHeight = 4;
	public float minJumpHeight = 0.5f;
	public float timeToJumpApex = .4f;
	float gravity;
	public float horizontalJump;
	float maxJumpVelocity;
	float minJumpVelocity;
	float accelerationTimeAirborn = .1f;
	float accelerationTimeGrounded = .05f;
	Vector2 defaultCollisionOffset;
	Vector2 defaultCollisionSize;

	[HideInInspector]
	public Vector3 velocity;
	float velocityXSmoothing;

	[HideInInspector]
	public Controller2D controller;
	BoxCollider2D boxCollider;

	[HideInInspector]
	Vector2 directionalInput;

	public UnityEvent OnLandEvent;
	bool isFacingRight = true;

	bool animGrounded;
	bool animCrouching;
	bool animJumpAscend;
	bool animFalling;

	void OnEnable(){
		canInputMovement = true;
	}

	private void Awake() {
		if(OnLandEvent == null) {
			OnLandEvent = new UnityEvent();
		}
	}

	void Start() {
		controller = GetComponent<Controller2D>();
		boxCollider = GetComponent<BoxCollider2D>();

		defaultCollisionOffset = boxCollider.offset;
		defaultCollisionSize = boxCollider.size;

		gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
	}

	void Update() {
		CalculateVelocity();
		SetSpriteDirection();
		// maybe once done with all this animation stuff, move it to a new class so it
		// doesn't clutter up the player script
		SetAnimationTriggers();

		controller.Move(velocity * Time.deltaTime, directionalInput);
		
		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			}
			else {
				velocity.y = 0;
			}
		}
	}

	void SetAnimationTriggers() {

		if (controller.collisions.below) {
			// Grounded
			animGrounded = Convert(animGrounded, true, GameEvents.instance.GroundedTrigger);

			animJumpAscend = Convert(animJumpAscend, false, null);

			if (animGrounded) {
				animFalling = Convert(animFalling, false, null);
			}

			if (isCrouchInput) {
				animCrouching = Convert(animCrouching, true, null);
			}
		}

		if (!controller.collisions.below && velocity.y < -10f) {
			// Falling
			animFalling = Convert(animFalling, true, GameEvents.instance.FallingTrigger);

			animJumpAscend = Convert(animJumpAscend, false, null);
			animGrounded = Convert(animGrounded, false, null);
		}
	}

	bool Convert(bool anim, bool value, Action function) {
		if (anim == value) return anim;
		anim = value;
		if (function != null) {
			function();
		}
		return anim;
	}

	public void SetDirectionalInput(Vector2 input) {
		directionalInput = input;
	}
	
	void SetSpriteDirection() {

		if (velocity.x < 0 && isFacingRight) {
			Flip();
			isFacingRight = false;
		}
		
		if (velocity.x > 0 && !isFacingRight) {
			Flip();
			isFacingRight = true;
		}
	}
	
	void Flip() {
		Vector3 spriteScale = transform.GetChild(0).localScale;
		spriteScale.x *= -1;
		transform.GetChild(0).localScale = spriteScale;
	}
	
	
	public void OnJumpInputDown() {

		if (controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				if(directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x)) { // not jumping against max slope
					velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
					velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
				}
			}
			else {
				velocity.y = maxJumpVelocity;
				velocity.x = horizontalJump;
			}
		}
	}

	public void OnCrouchInputDown() {
		isCrouchInput = true;
		if (controller.collisions.below) {
				animCrouching = Convert(animCrouching, true, GameEvents.instance.CrouchingTrigger);
		}
	}

	public void OnCrouchInputUp() {
		moveSpeedActual = moveSpeedTarget;
		isCrouchInput = false;
		animCrouching = Convert(animCrouching, false, null);
		GameEvents.instance.LocomotionTrigger();
	}
	
	public void StopMovement(){
		canInputMovement = false;
		directionalInput = new Vector2(0, 0);
		velocity = new Vector2(0, 0);
	}
	
	void CalculateVelocity() {
		float targetVelocityX = directionalInput.x * moveSpeedActual;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborn);
		velocity.y += gravity * Time.deltaTime;
	}
}