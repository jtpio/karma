using UnityEngine;
using System.Collections;

public class GiveMoney : MonoBehaviour {
	
	public float dist;

	Transform t;
	Transform player;
	MoneyCounter moneyCounter;
	bool hasMoney;
	Transform[] children;
	public Transform money;

	void Start () {
		player = GameObject.Find("Player").transform;
		moneyCounter = player.GetComponent<MoneyCounter>();
		t = transform;
		hasMoney = true;
		//money = transform.Find("Suitcase");
	}

	void Update () {
		if (hasMoney && Vector3.Distance(player.position, t.position) < dist) {
			if(Input.GetMouseButtonDown(0)){
				Destroy(money.gameObject);
				hasMoney = false;
				moneyCounter.incMoney();
				GetComponent<NavMeshAgent>().speed += 3.0f;
			}
		}
	}

}
