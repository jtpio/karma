using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public int numberWanderingHomeless;
	public Transform homelessPrefab;

	float width = 50;
	float height = 50;

	Vector3 raycastPos;
	float rayCastHeight = 1000.0f;

	LayerMask layerGround, layer;
	
	void Start () {

		layerGround = LayerMask.NameToLayer("Ground");
		layer = (1 << layerGround);

		Vector3 raycastPos = new Vector3(0, rayCastHeight, 0);
		for (int i = 0; i < numberWanderingHomeless; i++) {
			RaycastHit hit;
			do {
				float x = Random.Range(0, width);
				float z = Random.Range(0, height);
				raycastPos = new Vector3(x, rayCastHeight, z);
				Debug.Log (x + ", " + z);
			} while (!Physics.Raycast(raycastPos, -Vector3.up, out hit, Mathf.Infinity, layer));
			Vector3 hitPos = new Vector3(hit.point.x, 0.5f, hit.point.z);

			Instantiate(homelessPrefab, hitPos, Quaternion.identity);
		}
	}

	void Update () {
	
	}
}
