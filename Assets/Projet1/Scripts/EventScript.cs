using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour {

	void OnGUI () {
		if (Input.GetButtonDown ("Cancel")) {
			//Debug.Log("Sucses!");
			Application.LoadLevel(0);
		}
	}

	public static void gamePause (bool pause) {
		if (pause)	
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}


}
