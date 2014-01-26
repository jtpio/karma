using UnityEngine;
using System.Collections;

public class CatsAndDogs : MonoBehaviour {

	public Transform cat;
	public Transform dog;

	public Transform tr1;
	public Transform tr2;

	Vector3 pos1;
	Vector3 pos2;

	void Start () {
		pos1 = tr1.position;
		pos2 = tr2.position;
	}

	void Update () {
		if (MoneyCounter.state == MoneyCounter.State.LOSING || MoneyCounter.state == MoneyCounter.State.LOST) {
			if (Random.Range(0, 4) == 1) {
				Transform t = Instantiate(cat, new Vector3(Random.Range(pos1.x, pos2.x), 100, Random.Range(pos1.z, pos2.z)), Quaternion.identity) as Transform;
				t.gameObject.AddComponent<Rigidbody>(); t.GetComponent<Rigidbody>().mass = 45;
				Transform t2 = Instantiate(dog, new Vector3(Random.Range(pos1.x, pos2.x), 100, Random.Range(pos1.z, pos2.z)), Quaternion.identity) as Transform;
				t2.gameObject.AddComponent<Rigidbody>(); t2.GetComponent<Rigidbody>().mass = 45;
			}
		}

	}
}
