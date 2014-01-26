using UnityEngine;
using System.Collections;

public class GrabAnimation : MonoBehaviour {
	
	AudioSource grabSound;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		AudioSource[] sources = player.GetComponents<AudioSource>();;
		grabSound = sources[1];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Screen.lockCursor = true;
			if (!animation.isPlaying) grabSound.Play();
			animation.Play("Grab");
		}

	}
}
