using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PicselScript : MonoBehaviour {

	public static List<GameObject> picsels = new List<GameObject>();

	void Awake() {
		picsels.Add (this.gameObject);
	}

	void OnDestroy() {
		picsels.Remove (this.gameObject);
	}

	void FixedUpdate() {
		for (int i = 0; picsels.Count > i; i++) {
			if (gameObject != picsels[i]) {

			}
		}
	}

}
