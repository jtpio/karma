using UnityEngine;
using System.Collections;

public class FlipOffAnimatIon : MonoBehaviour {

	AudioSource flipSound;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		AudioSource[] sources = player.GetComponents<AudioSource>();;
		flipSound = sources[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)){
			if (!animation.isPlaying) flipSound.Play();
			animation.Play("MiddleFinger");
		}
	}
}
