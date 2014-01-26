using UnityEngine;
using System.Collections;

public class CameraPath : MonoBehaviour {

	bool loaded = false;

	void Start () {
		//StartCoroutine("Load");
		iTween.MoveBy(gameObject, iTween.Hash("y", 3, "easeType", "linear", "loopType", "pingpong", "time", 3));
	}

	void Update () {
		if (Input.anyKey){// && loaded) {
			iTween.Stop();
			loaded = false;
			iTween.MoveBy(gameObject, iTween.Hash("z", 40, "easeType", "easeInQuad", "onComplete", "OnComplete", "time", 0.2));
		}
	}

	void OnUpdate(float v) {
		
	}

	void OnComplete() {
		Application.LoadLevel(1);
	}

	IEnumerator Load() {
		AsyncOperation async = Application.LoadLevelAsync(1);
		yield return async;
		loaded = true;
		Debug.Log("Loading complete");
	}
}
