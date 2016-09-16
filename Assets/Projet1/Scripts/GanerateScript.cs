using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GanerateScript : MonoBehaviour {
	
	public static Vector2 PlayerEat;
	//public Transform Mark;
	public Transform Picsel1;
	public Transform Wall;
	public Transform Background;
	public Transform Water;
	public int Picsel1Count;
	public int WaterCount = 14;
	private float WaterScale;
	public static Vector2 mapSize = new Vector2(5 ,5);	 

	void Start () {
		//if (PlayerPrefs.GetInt("save") == 1) loadSettings();

		Background.localScale = new Vector3 (mapSize.x, mapSize.y, 0);
		Instantiate (Background, new Vector2 (0, 0), Background.rotation);
		Wall.localScale = new Vector3 (mapSize.x, mapSize.y, 0);
		Instantiate (Wall, new Vector2 (0, 0), Wall.rotation);

		//Instantiate (Mark, new Vector2(30, 16), Mark.rotation);
		//Instantiate (Mark, new Vector2(-30, 16), Mark.rotation);
		//Instantiate (Mark, new Vector2(30, -16), Mark.rotation);
		//Instantiate (Mark, new Vector2(-30, -16), Mark.rotation);

		for (int i = 0; i < Picsel1Count; i++) {
			Instantiate(Picsel1, new Vector3 (Random.Range(-mapSize.x,mapSize.x),
			                                  Random.Range(-mapSize.y,mapSize.y), -10), Picsel1.rotation);
		}

		for (int i = 0; i < WaterCount; i++) {
			Instantiate(Water, new Vector3 (Random.Range(8-mapSize.x,mapSize.x-8),
			                                Random.Range(8-mapSize.y,mapSize.y-8), -1), Water.rotation);
		}

		BehaviourScript.mapDistanceReaction = new Vector2 (mapSize.x - BehaviourScript.distanceReaction,
		                                                   mapSize.y - BehaviourScript.distanceReaction);
	}

	void loadSettings () {
		float ms = PlayerPrefs.GetFloat ("mapSize")/4;
		mapSize = new Vector2 (ms * mapSize.x, ms * mapSize.y);
		Background.localScale *= ms;
		Wall.localScale *= ms;
		WaterCount *= (int)ms;

		Picsel1Count = PlayerPrefs.GetInt ("picselCount");
	}

}