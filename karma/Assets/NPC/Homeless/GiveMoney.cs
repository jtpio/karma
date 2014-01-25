using UnityEngine;
using System.Collections;

public class GiveMoney : MonoBehaviour {
	
	public float dist;

	Transform _transform;
	Transform player;
	MoneyCounter moneyCounter;
	bool hasMoney;
	Transform[] children;
	Transform money1;
	Transform money2;
	Transform money3;

	void Start () {
		player = GameObject.Find("Player").transform;
		moneyCounter = player.GetComponent<MoneyCounter>();
		_transform = transform;
		hasMoney = true;
		money1 = transform.FindChild("polySurface7");
		money2 = transform.FindChild("polySurface8");
		money3 = transform.FindChild("polySurface9");
	}

	void Update () {
		if (hasMoney && Vector3.Distance(player.position, _transform.position) < dist) {
			if(Input.GetMouseButtonDown(0)){
				Destroy(money1.gameObject);
				Destroy(money2.gameObject);
				Destroy(money3.gameObject);
				hasMoney = false;
				moneyCounter.incMoney();
			}
		}
	}

}
