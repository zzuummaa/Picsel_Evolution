using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public CameraControllerScript cameraController;
	public Transform Mark;

	public Vector2 speed = new Vector2(18, 18);
	private Vector2 direction = new Vector2(0, 0);
	private Vector3 movement;

	// Update is called once per frame
	void Update () {
		float inputx = Input.GetAxis ("Horizontal");
		float inputy = Input.GetAxis ("Vertical");

		direction = new Vector2 (inputx, inputy).normalized;

		movement = new Vector3 (speed.x * direction.x,
	                            speed.y * direction.y);
		//Debug.Log ();
	}

	void FixedUpdate() {rigidbody2D.velocity = movement;}

	void OnDestroy() {
		if (Mark == null) return;
		Mark.transform.position = transform.position;
		cameraController.player = Mark.transform;
		//EventScript.gamePause (true);
	}
}
