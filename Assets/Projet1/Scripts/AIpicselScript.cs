using UnityEngine;
using System.Collections;

public class AIpicselScript : MonoBehaviour {
	public static Vector2 speed = new Vector2 (15f, 15f);
	public static float MapDistanceReaction;
	private Vector2 direction;
	private Vector3 Position;
	private static int i;

	void Start () {
		transform.position = new Vector3 (Random.Range (-GanerateScript.mapSize.x, GanerateScript.mapSize.x),
		                                  Random.Range (-GanerateScript.mapSize.y, GanerateScript.mapSize.y), -10);
		Situation = Switch.of;
	}


	private enum Switch {
		WalReact, PlayerReact, Picsel1React, of
	}

	private Switch Situation;

//	void OnTriggerEnter2D (Collider2D c) {
		//На каждый кадр будет проверяться расстояние только до 1 пикселя
//		if (c.tag == "Picsel1" && (Situation == Switch.of | Situation == Switch.WalReact)) {
//			Situation = Switch.Picsel1React;
//			cg = c.gameObject;
//		}
//		if (c.tag == "Player") {
//			Situation = Switch.PlayerReact;
//			cg = c.gameObject;
//		}
//	}

	void OnTriggerStay2D (Collider2D c) {
		if (c.tag == "Player") {
			Situation = Switch.PlayerReact;
			Position = c.transform.position;
		}
		if (c.tag == "Picsel1" && Situation == Switch.of) {
			Situation = Switch.Picsel1React;
			Position = c.transform.position;
		}
		i += i;

	}

	void Update () {
		if (Situation == Switch.of){
			WallReaction (Picsel: gameObject);
			//Debug.Log("Wall");
		}
		if (Situation == Switch.Picsel1React) {
			PlayerReaction (Player: Position);
			//Debug.Log ("Picsel");
		}
		if (Situation == Switch.PlayerReact) {
			PlayerReaction (Player: Position);
			direction = new Vector2 (direction.x * -1, direction.y * -1);
			//Debug.Log("Player");
		}
		i = 0;



		direction = new Vector2 (0, 0);
		Situation = Switch.of;
	}

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void WallReaction (GameObject Picsel) {
		if (Picsel.transform.position.x > GanerateScript.mapSize.x - MapDistanceReaction) {
			direction.x = -1;  
		}
		if (Picsel.transform.position.x < -GanerateScript.mapSize.x + MapDistanceReaction) {
			direction.x = 1;
		} 
		if (Picsel.transform.position.y > GanerateScript.mapSize.y - MapDistanceReaction) {
			direction.y = -1;  
		}
		if (Picsel.transform.position.y < -GanerateScript.mapSize.y + MapDistanceReaction) {
			direction.y = 1;
		}
	}

	//Передаются значения для преследования
	void PlayerReaction (Vector3 Player) {
		if (transform.position.x - Player.x > 0) {direction.x = -1;} 
		if (transform.position.x - Player.x < 0) {direction.y = 1;}
		if (transform.position.y - Player.y > 0) {direction.y = -1;} 
		if (transform.position.y - Player.y < 0) {direction.y = 1;}
	}

}