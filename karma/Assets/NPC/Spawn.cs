using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	
	public Transform prefab;
	public float speed;

	void Start () {
		Transform[] wayPoints = new Transform[transform.childCount];
		List<Transform> ts = new List<Transform>();
		foreach (Transform t in transform) ts.Add(t);

		foreach(Transform t in ts) {
			Transform tr = Instantiate(prefab, t.position, Quaternion.identity) as Transform;
			tr.GetComponent<Move>().SetWayPoints(ts);
			tr.GetComponent<Move>().SetTarget(t);
			tr.GetComponent<Move>().SetSpeed(speed);
		}
	}

	void Update () {
	
	}


}
