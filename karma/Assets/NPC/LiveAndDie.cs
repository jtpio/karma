using UnityEngine;
using System.Collections;

public class LiveAndDie : MonoBehaviour {
	
	public float life;

	float time;

	void Start () {
		time = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > life) Destroy(gameObject);
	}
}
