using UnityEngine;
using System.Collections;

public class CameraPath : MonoBehaviour {


	void Start () {
		//StartCoroutine("Load");
		iTween.MoveBy(gameObject, iTween.Hash("y", 3, "easeType", "linear", "loopType", "pingpong", "time", 3));
	}

	void Update () {
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter) ) {// && loaded) {
			iTween.Stop();
			iTween.MoveBy(gameObject, iTween.Hash("z", 40, "easeType", "easeInQuad", "onComplete", "OnComplete", "time", 0.2));
		}
	}

	void OnUpdate(float v) {
		
	}

	void OnComplete() {
		Application.LoadLevel(1);
	}

}
