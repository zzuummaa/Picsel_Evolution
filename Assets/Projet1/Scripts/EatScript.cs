using UnityEngine;
using System.Collections;

public class EatScript : MonoBehaviour {
	
	void OnCollisionStay2D (Collision2D c){
		if (c.transform.localScale.x < transform.localScale.x) {
			//Берем кубическй корень из суммы кубов пикселей

			float objectScale = Mathf.Pow(Mathf.Pow(transform.localScale.x,3)
			                            + Mathf.Pow(1.2f * c.transform.localScale.x,3),1.0f/3);

			this.transform.localScale = new Vector2(objectScale, objectScale); 
			Destroy(c.gameObject);
		}
	}
}
