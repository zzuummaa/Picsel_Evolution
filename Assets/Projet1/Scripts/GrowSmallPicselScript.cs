using UnityEngine;
using System.Collections;

public class GrowSmallPicselScript : MonoBehaviour {
	public float GrowSpeed;
	public GameObject Picsel1;
	private float scale;

	void Awake () {
		UserInterfaceScript.picselCount += 1; 
		scale = 0.3f / GrowSpeed;
	}
	void OnDestroy () {UserInterfaceScript.picselCount -= 1;}

	void Update () {
		float s = scale * Time.deltaTime;

		transform.localScale = new Vector3 (s + transform.localScale.x, s + transform.localScale.y, 1);
		if (gameObject.transform.localScale.x >= 0.5f) {
			Instantiate(Picsel1, transform.position, transform.rotation);
			Destroy(gameObject);

		}
	}
}
