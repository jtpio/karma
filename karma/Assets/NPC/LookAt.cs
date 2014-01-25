using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public float playerDistance;

	Transform player;
	
	void Start () {
		player = GameObject.Find("Player").transform;
	}
	
	void Update () {
		if (Vector3.Distance(player.position, transform.position) < playerDistance) {
			var rot = Quaternion.LookRotation(player.position-transform.position);
			Vector3 e = (rot * transform.parent.rotation).eulerAngles;
			//e.x = 0;
			e.y = 0;
			//e.z = 0;
			transform.rotation = Quaternion.Euler(e);
		}
	}
}
