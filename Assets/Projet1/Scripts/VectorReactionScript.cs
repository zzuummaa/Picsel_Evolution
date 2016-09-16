using UnityEngine;
using System.Collections;
public class VectorReactionScript : MonoBehaviour {
	
	public float playerPositionCheckCount = 2;
	private float playerCheckCount = 0;
	private Vector2 movement;
	private Vector2 vectorDirection = new Vector2(0, 0);
	private Vector2 direction = new Vector2 (0, 0);
	public Vector2 speed = new Vector2 (5.5f, 5.5f);
	public static float MapDistanceReaction = 10f;
	private static float PlayerDistanceReaction = 10f;
	private int i = 1;
	
	void FixedUpdate() {
		direction = vectorDirection.normalized;
		
		//		if (vectorDirection != new Vector2 (0,0))
		//		Debug.Log("dx = " + direction.x + 
		//		          " dy = " + direction.y);
		
		movement = new Vector2 (direction.x * speed.x,
		                        direction.y * speed.y);
		
		rigidbody2D.velocity = movement;
		
		vectorDirection = new Vector2 (0, 0);
	}
	
	void OnTriggerStay2D (Collider2D c){
		if (c.tag == "Player" || c.tag == "Wall") {
			vectorDirection = DangerReaction(new Vector2(c.transform.position.x, c.transform.position.y)) + vectorDirection;
			
			//			Debug.Log("vx = " + vectorDirection.x + 
			//			         " vy = " + vectorDirection.y);
		}
	}
	
	Vector2 DangerReaction (Vector2 cPosition) {
		float x = transform.position.x - cPosition.x;
		float y = transform.position.y - cPosition.y;
		
		return new Vector2 (x, y).normalized * 11 - new Vector2 (x, y);
	}
	
}
