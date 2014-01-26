using UnityEngine;
using System.Collections;

public class GiveMoneyHobo : MonoBehaviour {
	
	public float dist;
	public Transform money;

	Transform _transform;
	Transform player;
	Transform model;
	MoneyCounter moneyCounter;
	bool hasMoney;
	Transform[] children;
	Move move;


	AudioSource hoboSound;
	AudioSource hoboCry;

	void Start () {
		AudioSource[] sources = GetComponents<AudioSource>();
		hoboSound = sources[0];
		hoboCry = sources[1];
		player = GameObject.Find("Player").transform;
		model = transform.FindChild("char_hobo");
		move = GetComponent<Move>();
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
				hoboSound.Stop();
				model.animation.Play("Die");
				hoboCry.Play();
				move.SetTarget(null);
			}
		}
	}

}
