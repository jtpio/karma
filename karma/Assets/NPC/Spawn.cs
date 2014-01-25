using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	
	public Transform homelessPrefab;

	void Start () {
		Transform[] wayPoints = new Transform[transform.childCount];
		List<Transform> ts = new List<Transform>();
		foreach (Transform t in transform) ts.Add(t);


		foreach(Transform t in ts) {
			Transform tr = Instantiate(homelessPrefab, t.position, Quaternion.identity) as Transform;
			tr.GetComponent<Move>().SetWayPoints(ts);
			tr.GetComponent<Move>().SetTarget(t);
		}
	}

	void Update () {
	
	}


}
