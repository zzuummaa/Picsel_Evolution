using UnityEngine;
using System.Collections;
using System;

public class MenuScript : MonoBehaviour {
	private int window;
	private int menu;

	public int picselCount;
	public float mapSize;

	void Start () {
		picselCount = PlayerPrefs.GetInt ("picselCount", 90);
		mapSize = PlayerPrefs.GetFloat ("mapSize", 4f);
		window = 1;
		menu = 1;
	}

	void OnGUI () {
		if (menu == 1)
			mainMenu();
		if (menu == 2)
			settings();
	}

	void mainMenu () {
		GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
		
		if (window == 1) {
			if (GUI.Button (new Rect(10,30,180,30), "Играть")) {window = 2;}
			if (GUI.Button (new Rect(10,70,180,30), "Настройки")) {window = 3;}
			if (GUI.Button (new Rect(10,110,180,30), "Выход")) {window = 4;}
		}
		
		if (window == 2) {
			Application.LoadLevel (1);
		}
		if (window == 3) {
			menu = 2; window = 1;
		}
		if (window == 4) {
			Application.Quit ();
		}
		
		GUI.EndGroup ();
	}

	void settings () {
		
		if (window == 1) {

			GUI.Window (0, new Rect(Screen.width/2 - 200, Screen.height/2 - 130, 400, 200), settingsWindow, "Настройки генерации карты");
			if (GUI.Button (new Rect(Screen.width/2 - 130, Screen.height/2 + 80, 90, 30), "Назад")) {window = 2;}
			if (GUI.Button (new Rect(Screen.width/2 + 40, Screen.height/2 + 80, 90, 30), "Сохранить")) {window = 3;}
		}
		
		if (window == 2) {
			menu = 1; window = 1;
		}
		if (window == 3) {
			SaveSettingsScript.save(this);
			window = 1;
		}
	}

	void settingsWindow (int windowId) {
		GUI.Label (new Rect(10, 30, 140, 30), "Количество пикселей");
		picselCount = (int)GUI.HorizontalSlider (new Rect(155, 35, 140, 30), (float)picselCount, 0f, 300f);
		GUI.Label (new Rect(315, 30, 90, 30), Convert.ToString(picselCount));

		GUI.Label (new Rect(10, 70, 140, 30), "Размер карты");
		mapSize = GUI.HorizontalSlider (new Rect(155, 75, 140, 30), mapSize, 1f, 100f);
		GUI.Label (new Rect(315, 70, 90, 30), Convert.ToString((int)mapSize));
	}
}
