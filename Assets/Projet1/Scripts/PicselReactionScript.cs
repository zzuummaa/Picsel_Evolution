using UnityEngine;
using System.Collections;

public class PicselReactionScript : MonoBehaviour {
	
	private bool directEnable = false;
	public float playerPositionCheckCount = 2;
	private float playerCheckCount = 0;
	private Vector2 movement;
	private Vector2 direction = new Vector2 (0, 0);
	public Vector2 speed = new Vector2 (5.5f, 5.5f);
	public static float MapDistanceReaction = 10f;
	private static float PlayerDistanceReaction = 10f;
	private int i = 1;

	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}

	void OnTriggerStay2D (Collider2D c){
		if (c.gameObject.tag == "Player"){
			PlayerReaction(c.gameObject);
			WallReaction(c.gameObject);
		}

//		if (c.gameObject.transform.localScale.x < transform.localScale.x) {
//			PlayerReaction(c.gameObject);
//			direction = new Vector2(direction.x * -1,
//			                        direction.y * -1);
//		}
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.gameObject.tag == "Player") playerCheckCount = playerPositionCheckCount;
	}

	void Update() { 
		if (playerCheckCount > 0) playerCheckCount -= Time.deltaTime;	
		if (playerCheckCount < 0) playerCheckCount = 0;
		if (playerCheckCount == 0)direction = new Vector2(0, 0);	

		movement = new Vector2 (direction.x * speed.x,
		                        direction.y * speed.y);
	}

	void PlayerReaction (GameObject PlayerPicsel) {
		if (PlayerPicsel.transform.position.x < transform.position.x)
		{direction.x = 1;}
		else
		{direction.x = -1;}
		
		if (PlayerPicsel.transform.position.y < transform.position.y)
		{direction.y = 1;}
		else
		{direction.y = -1;}
	}

	void WallReaction (GameObject PlayerPicsel) {
		if (PlayerPicsel.transform.position.x > GanerateScript.mapSize.x - MapDistanceReaction) {
			direction.x = -1;  
			directEnable = true;
		}
		if (PlayerPicsel.transform.position.x < -GanerateScript.mapSize.x + MapDistanceReaction) {
			direction.x = 1;
			directEnable = true;
		} 
		if (PlayerPicsel.transform.position.y > GanerateScript.mapSize.y - MapDistanceReaction) {
			direction.y = -1;  
			directEnable = true;
		}
		if (PlayerPicsel.transform.position.y < -GanerateScript.mapSize.y + MapDistanceReaction) {
			direction.y = 1;
			directEnable =true;
		}
	}
	
}
