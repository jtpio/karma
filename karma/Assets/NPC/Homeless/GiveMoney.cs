using UnityEngine;
using System.Collections;

public class GiveMoney : MonoBehaviour {
	
	public float dist;

	Transform _transform;
	Transform player;
	MoneyCounter moneyCounter;
	bool hasMoney;
	Transform[] children;
	Transform money;

	void Start () {
		player = GameObject.Find("Player").transform;
		moneyCounter = player.GetComponent<MoneyCounter>();
		_transform = transform;
		hasMoney = true;
		money = transform.FindChild("Money");
	}

	void Update () {
		if (hasMoney && Vector3.Distance(player.position, _transform.position) < dist) {
			Destroy(money.gameObject);
			hasMoney = false;
			moneyCounter.incMoney();
		}
	}

}
