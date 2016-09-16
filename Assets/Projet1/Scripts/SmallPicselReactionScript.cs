using UnityEngine;
using System.Collections;

public class SmallPicselReactionScript : BehaviourScript {

	private Vector2 awakePosition;
	private Vector2 direction = new Vector2 (1, 1);
	public float speed = 3f;
	public float MapDistanceReaction;
	private Vector2 movement;
	public float timerDirection = 3f;
	private float timer = 0;

	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}

	public enum Switch {
		WalReact, PlayerReact, Water, of
	}

	private Switch Situation = Switch.of;
	
	void OnTriggerStay2D (Collider2D collider){
		//8-"UnDanger"

//		    direction = new Vector2 (0, 0);
		    check (go: collider.gameObject);

		    if (Situation == Switch.PlayerReact) {
		    	PlayerReaction (PlayerPicsel: collider.gameObject);
		    }

		    if (Situation == Switch.WalReact) {
//		    	Debug.Log("WallReact");
		    	WallReaction (PlayerPicsel: collider.gameObject);
		   }
	}

	void Update () {
//		Debug.Log ("Situation = " + Situation);
		if (Situation == Switch.of) {
			Of();
		}

		movement = new Vector2 (direction.x * speed,
		                        direction.y * speed);
	}

	void OnTriggerEnter2D () {
			speed = 3f;
	}

	void OnTriggerExit2D () {
		speed = 2f;
		Situation = Switch.of;
//		Debug.Log ("Trigger Exit");
	}

	void check (GameObject go) {
		Situation = Switch.of;

		if (go.tag != tag) {
			if (go.tag == "Player" || go.tag == "Picsel") {
					Situation = Switch.PlayerReact;
			}

			if (go.tag == "Wall") {
					Situation = Switch.WalReact;
			}
//		    Debug.Log ("Situation after check = " + Situation);
		}
	}

	void PlayerReaction (GameObject PlayerPicsel) {
		
		if (PlayerPicsel.transform.position.x < transform.position.x)
		{direction.x = 1;}
		else
		{direction.x = -1;}
		
		if (PlayerPicsel.transform.position.y < transform.position.y)
		{direction.y = 1;}
		else
		{direction.y = -1;};
	}
	
	void WallReaction (GameObject PlayerPicsel) {
		if (this.transform.position.x > GanerateScript.mapSize.x - MapDistanceReaction) {
			direction.x = -1;  
		}
		if (this.transform.position.x < -GanerateScript.mapSize.x + MapDistanceReaction) {
			direction.x = 1;
		} 
		if (this.transform.position.y > GanerateScript.mapSize.y - MapDistanceReaction) {
			direction.y = -1;  
		}
		if (this.transform.position.y < -GanerateScript.mapSize.y + MapDistanceReaction) {
			direction.y = 1;
		}
	}

	void Of () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			if ((int)Random.Range(0, 1) == (int)Random.Range(0, 1))
				direction = new Vector2(awakePosition.x - transform.position.x,
				                        awakePosition.y - transform.position.y).normalized;
			else
				direction = new Vector2((int)Random.Range(-1, 1), (int)Random.Range(-1, 1));

			timer = timerDirection;

		} 
	}	
}
