using UnityEngine;
using System.Collections;

public class CornerReactionScript : MonoBehaviour {

	private float[] corners = new float[30];
	public float playerPositionCheckCount = 2;
	private float playerCheckCount = 0;
	private Vector2 movement;
	private Vector2 vectorDirection = new Vector2(0, 0);
	private Vector2 direction = new Vector2 (0, 0);
	public Vector2 speed = new Vector2 (5.5f, 5.5f);
	public static float MapDistanceReaction = 10f;
	private static float PlayerDistanceReaction = 10f;
	private int i = 1;
	private int k = 0;

	void FixedUpdate() {
		if (corners[0] != null){
			Debug.Log (corners[0] * Mathf.PI);
			corners = new float[30];
			k = 0;
		}

	}

	void OnTriggerEnter2D (Collider2D c) {
		Vector2 pl = new Vector2 (transform.position.x, transform.position.y);
		Vector2 cl = new Vector2 (c.transform.position.x, c.transform.position.y); 
		if (c.tag == "Player") {
			float cos = (pl.x*cl.x + pl.y*cl.y)/Mathf.Sqrt( (pl.x*pl.x + pl.y*pl.y)*(cl.x*cl.x + cl.y*cl.y) );
			corners[k++] = Mathf.Acos(cos);
		}
	}

	void Update () {

	}
}
