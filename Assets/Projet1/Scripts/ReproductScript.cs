using UnityEngine;
using System.Collections;

public class ReproductScript : MonoBehaviour {

	public static int MaxPicsels = 150;
	public int chance = 100;
	public float Timer = 10;
	public GameObject Picsel1Small;
	private float TimerControl;
	
	void Awake () {UserInterfaceScript.picselCount += 1;}
	void OnDestroy() {UserInterfaceScript.picselCount -= 1;}

	void Start () {
		TimerControl = Timer;
	}

	void FixedUpdate () {
//		Debug.Log ("i = " + i);
	}
	
	void Update () {
		if (TimerControl > 0)   {TimerControl -= Time.deltaTime;} 
		if (TimerControl < 0)  {TimerControl = 0;}
		if (TimerControl == 0) {
		//Debug.Log("Timer Sucsess!");
		TimerControl = Timer;
			if (Random.Range(1, chance) == 1 && UserInterfaceScript.picselCount <= MaxPicsels)
			{//Debug.Log("Random Acses!");
				Transform tr = gameObject.transform;
				float around = 0.2f;
				int n = (int)(8 * transform.localScale.x);

				for (int i = 0; i <= n; i++)			    
					Instantiate (Picsel1Small, tr.position, tr.rotation);
			    //Instantiate (Picsel1Small, new Vector3 (tr.position.x + around, tr.position.y, -10), tr.rotation);
				//Instantiate (Picsel1Small, new Vector3 (tr.position.x, tr.position.y + around, -10), tr.rotation);
				//Instantiate (Picsel1Small, new Vector3 (tr.position.x + around, tr.position.y + around, -10), tr.rotation);
			    Destroy (gameObject);}
		}
	}
}
