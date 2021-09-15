using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
	PlayerAttack playerAttack;
	Vector2 directionalInput = new Vector2(0f, 0f);
	float moveDownInput;
	
	public AudioSource rabouschJump;
	
	void Start() {
		player = GetComponent<Player>();
		playerAttack = GetComponent<PlayerAttack>();
	}

	private void Update() {
		if (player.canInputMovement) {
			directionalInput.x = 1f;
			player.SetDirectionalInput(directionalInput);
		}

		if (Input.GetKeyDown(KeyCode.LeftControl)) {
			player.OnCrouchInputDown();
		}

		if (Input.GetKeyUp(KeyCode.LeftControl)) {
			player.OnCrouchInputUp();
		}
	}
	
	public void Attack(){
		if(player.canInputMovement){
			playerAttack.Attack();
		}
	}
	
	public void Jump(){
		if(player.canInputMovement){
			rabouschJump.Play();
			player.OnJumpInputDown();
		}
	}
	
	public void MoveDown(){
		if(player.canInputMovement){
			directionalInput.y = -1f;
			Invoke("ReturnDirecInput", 0.3f);
		}
	}
	
	void ReturnDirecInput(){
		directionalInput.y = 0;
	}
}
