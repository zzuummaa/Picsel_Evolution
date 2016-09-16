using UnityEngine;
using System.Collections;
public class OnEatScript : MonoBehaviour {

	public static Vector2 PicselSize1;
	

	void OnCollisionStay2D (Collision2D collision1) {

		if (collision1.gameObject.tag == "Player" ) {
		  PicselSize1 = transform.localScale;
		  Destroy (gameObject);
		}
    }

}
