using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {

	public float wayPointDist;

	Transform t;
	Transform target;
	NavMeshAgent agent;
	List<Transform> wayPoints;

	void Awake() {
		t = transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && Vector3.Distance(target.position, t.position) < wayPointDist) {
			SetTarget(wayPoints[Random.Range(0, wayPoints.Count-1)]);
		}
	}

	public void SetWayPoints(List<Transform> ts) {
		wayPoints = ts;
	}

	public void SetTarget(Transform tr) {
		target = tr;
		agent.SetDestination(target.position);
	}

	public void SetSpeed(float speed) {
		agent.speed = speed;
	}

}