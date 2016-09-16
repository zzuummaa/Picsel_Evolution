using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour {

	public Transform player;
	public int distance = -10;
	private float lift =  0;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, lift, distance) + player.position;
		transform.LookAt (player);
	}
}
