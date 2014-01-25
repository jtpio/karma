using UnityEngine;
using System.Collections;

public class MoneyCounter : MonoBehaviour {

	public int moneyStart;
	public int moneyEnd;
	public int moneyStep;
	public int decrease;
	public string retryText;
	public GUIStyle style;
	public GUIStyle retryStyle;

	int money;
	enum State{
		COLLECT, LOSING, LOST
	}
	State state;

	void Start () {
		money = moneyStart;
		state = State.COLLECT;
	}
	
	void Update () {
		if(money <= 0) state = State.LOST;
	}

	public void incMoney() {
		if (state == State.COLLECT) {
			money += Random.Range(moneyStep / 2, moneyStep);
			if(money > moneyEnd) state = State.LOSING;
		}
	}

	public void OnGUI() {
		style.fontSize = (state == State.LOST) ? 42 + (int) (Mathf.Cos(Time.time * 10) * 10) : 42;
		GUI.Label(new Rect(5, 0, 150, 100), 
			"" + money, 
			style
		);

		if(state == State.LOSING){
			money -= (int)(Time.deltaTime * decrease);
		}

		if (state == State.LOST) {
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), retryText, retryStyle);
			money = 0;
			if (Input.GetKey(KeyCode.R)) {
				Application.LoadLevel(0);
			}
		}
	}
}