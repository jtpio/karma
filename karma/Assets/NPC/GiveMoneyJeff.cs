using UnityEngine;
using System.Collections;

public class GiveMoneyJeff : MonoBehaviour {
	
	public float dist;
	public Transform money;
	public AudioSource coinSound;
	
	Transform _transform;
	Transform player;
	MoneyCounter moneyCounter;
	bool hasMoney;
	Transform[] children;

	void Start () {
		AudioSource[] sources = GetComponents<AudioSource>();
		coinSound = sources[0];
		player = GameObject.Find("Player").transform;
		moneyCounter = player.GetComponent<MoneyCounter>();
		_transform = transform;
		hasMoney = true;
	}

	void Update () {
		if (hasMoney && Vector3.Distance(player.position, _transform.position) < dist) {
			if(Input.GetMouseButtonDown(0)){
				Destroy(money.gameObject);
				hasMoney = false;
				moneyCounter.incMoney();
				coinSound.Play();
			}
		}
	}

}
