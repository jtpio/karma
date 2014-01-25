using UnityEngine;
using System.Collections;

public class MoneyCounter : MonoBehaviour {

	public int moneyStart;
	public int moneyEnd;
	public int moneyStep;
	public string retryText;
	public GUIStyle style;
	public GUIStyle retryStyle;

	int money;
	bool lost;

	void Start () {
		money = moneyStart;
		lost = false;
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.R)) {
			Application.LoadLevel(0);
		}
	}

	public void incMoney() {
		if (!lost) {
			money += Random.Range(moneyStep / 2, moneyStep);
			lost = money > moneyEnd;
		}
	}

	public void OnGUI() {
		style.fontSize = (lost) ? 42 + (int) (Mathf.Cos(Time.time * 10) * 10) : 42;
		GUI.Label(new Rect(5, 0, 150, 100), 
			"" + money, 
			style
		);

		if (lost) GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), retryText, retryStyle);
	}
}