using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {
	
	void Start () {
		Screen.lockCursor = true;
	}

	void OnMouseDown() {
		Screen.lockCursor = true;
	}

	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			Screen.lockCursor = false;
		}

		if (Input.GetKey(KeyCode.Q)) {
			Application.Quit();
		}
	}
}
