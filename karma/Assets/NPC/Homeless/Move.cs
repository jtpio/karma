using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
	}

}