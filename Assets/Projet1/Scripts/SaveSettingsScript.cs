using UnityEngine;
using System.Collections;

public class SaveSettingsScript : MonoBehaviour {

	public static void save (MenuScript script) {
		PlayerPrefs.SetInt ("save", 1);
		PlayerPrefs.SetFloat ("mapSize", script.mapSize);
		PlayerPrefs.SetInt ("picselCount", script.picselCount);
	}
}
