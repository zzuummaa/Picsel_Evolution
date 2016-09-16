using UnityEngine;
using System.Collections;
using System;

public class UserInterfaceScript : MonoBehaviour {
	public Transform player;
	//public bool player;
	public static int picselCount = 0;
	private float time;
	private int fps;
	private int fps_count;
	
	void Start () {
		time = 1;
	}
	
	void Update () {
		time -= Time.deltaTime;
		fps_count += 1;
		if (time <= 0) {
			time = 1f;
			fps = fps_count;
			fps_count = 0;
		}
	}
	
	void OnGUI () {
		float sw = Screen.width;
		if (!player) {
			float sh = Screen.height;
			int indent = 25;

			GUIStyle style = new GUIStyle();
			style.normal.textColor = Color.black;
			style.fontSize = indent * 2;

			GUI.Label (new Rect(sw/2 - indent * 4, sh/2 - indent, 120, 100), "You lose!", style);
		} else {
			GUI.TextArea (new Rect(10, 10, 122, 25), "Ваш размер: " + Math.Round(player.transform.localScale.x, 3));
			GUI.TextArea (new Rect (sw - 60, 10, 55, 25), "fps:" + fps);
			GUI.TextArea (new Rect (sw - 215, 10, 148, 25), "Пикселей на карте: " + picselCount);
		}

	}
	
}
