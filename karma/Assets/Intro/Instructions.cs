using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public GUIStyle style;
	public string text;

	void Start () {
	}

	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel(1);
		}
	}

	void OnGUI () {
		style.fontSize = 42 + (int) (Mathf.Cos(Time.time * 10) * 20);
		var dim = style.CalcSize(new GUIContent(text));
		GUI.Label(new Rect(Screen.width / 2 - dim.x / 2, Screen.height / 2 - dim.y / 2, 200, 200), text, style);
	}
}
