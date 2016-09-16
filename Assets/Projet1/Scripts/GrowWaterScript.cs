using UnityEngine;
using System.Collections;

public class GrowWaterScript : MonoBehaviour {
	private float scale;
	//Назначаем размер воды
	void Start () {
		scale = transform.localScale.x;
		scale = Random.Range (scale/3, scale);
		gameObject.transform.localScale = new Vector3 (scale, scale, -1);
	}

//	void OnTriggerStay2D (Collider2D c){
//		if (c.gameObject.name == "Picsel1Small(Clone)") {

//		    scale = Time.deltaTime*0.1f;
//			c.gameObject.transform.localScale = c.gameObject.transform.localScale + new Vector3 (scale, scale, 1);
//		}
//	}
}
