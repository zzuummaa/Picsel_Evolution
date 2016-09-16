using UnityEngine;
using System.Collections;

public class CameraIntervaceScript : MonoBehaviour {
	public static float PicselWidth;
	public static int picselCount = 0;
	private float time;
	private int fps;
	private int fps_count;

	void Start () {
		time = 1;
		PicselWidth = 1.0f;
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
		GUI.TextArea (new Rect(10, 10, 145, 25), "Ваш размер: " + PicselWidth);
		GUI.TextArea (new Rect (sw - 60, 10, 45, 25), "fps:" + fps);
		GUI.TextArea (new Rect (sw - 215, 10, 148, 25), "Пикселей на карте: " + picselCount);
	}

}
