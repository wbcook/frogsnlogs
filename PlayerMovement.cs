using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidbody;
	[SerializeField]
	private RandomSoundPlayer playerFootsteps;

	// Use this for initialization
	void Start () {

		// Gather components from the Player GameObject
		playerAnimator = GetComponent<Animator> ();		// The player has built in animations
		playerRigidbody = GetComponent<Rigidbody> ();	// The player is affected by physics

	}
	
	// Update is called once per frame
	void Update () {

		// Gather input from the keyboard
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

	}

	void FixedUpdate () {

		// If the player's movement vector does not equal zero shorthand for (0,0,0)...
		if (movement != Vector3.zero) {

			// ... then create a target rotation based on the movement vector...
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);	// The movement vector and where "up" is in the game world for Quaternion reasons

			// ...and create another rotation that moves from the current rotation to the target rotation...
			Quaternion newRotation = Quaternion.Lerp (playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);

			// ...and change the player's rotation to the new incremental rotation...
			playerRigidbody.MoveRotation(newRotation);

			// ... then play the jump animation
			playerAnimator.SetFloat ("Speed", 3f);	// Set the speed to a floating point value of 3.

			// ...play footstep sounds
			playerFootsteps.enabled = true;

		} else {
			//... otherwise don't
			playerAnimator.SetFloat ("Speed", 0f);

			// ...don't play footstep sounds
			playerFootsteps.enabled = false;

		}

	}

}
