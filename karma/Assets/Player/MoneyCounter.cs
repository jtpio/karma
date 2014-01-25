using UnityEngine;
using System.Collections;

public class MoneyCounter : MonoBehaviour {

	public int moneyStart;
	public int moneyEnd;
	public int moneyStep;
	public int decrease;
	public string retryText;
	public GUIStyle style;
	public GUIStyle moneyGainStyle;
	public GUIStyle retryStyle;

	Hashtable htGotMoneyIn;
	Hashtable htGotMoneyOut;

	int gain = 0;
	float gotMoneyY = -70.0f;

	int money;
	enum State{
		COLLECT, LOSING, LOST
	}
	State state;

	void Start () {
		money = moneyStart;
		state = State.COLLECT;

		htGotMoneyIn = new Hashtable();
		htGotMoneyIn.Add("name", "moneyIn");
		htGotMoneyIn.Add("from", Screen.height + 70f);
		htGotMoneyIn.Add("to", Screen.height / 2);
		htGotMoneyIn.Add("time", 0.4f);
		htGotMoneyIn.Add("onupdate", "RaiseGain");
		htGotMoneyIn.Add("onComplete", "GainUpStop");
		htGotMoneyIn.Add("easetype", iTween.EaseType.easeInOutExpo);

		htGotMoneyOut = new Hashtable();
		htGotMoneyOut.Add("name", "moneyOut");
		htGotMoneyOut.Add("from", Screen.height / 2);
		htGotMoneyOut.Add("to", -70.0f);
		htGotMoneyOut.Add("time", 0.4f);
		htGotMoneyOut.Add("delay", 2.0f);
		htGotMoneyOut.Add("onupdate", "RaiseGain");
		//htGotMoneyOut.Add("onComplete", "GainUpFinished");
		htGotMoneyOut.Add("easetype", iTween.EaseType.easeOutQuad);
	}
	
	void Update () {
		if(money <= 0) state = State.LOST;
	}

	void RaiseGain(float v) {
		gotMoneyY = v;
	}

	void GainUpStop() {
		iTween.ValueTo(gameObject, htGotMoneyOut);
	}

	public void incMoney() {
		if (state == State.COLLECT) {
			gain = Random.Range(moneyStep / 2, moneyStep);
			money += gain;
			if(money > moneyEnd) state = State.LOSING;
			StopTweens();
			iTween.ValueTo(gameObject, htGotMoneyIn);
		}

	}

	void StopTweens() {
		iTween.StopByName("moneyIn");
		iTween.StopByName("moneyOut");
	}
	
	public void OnGUI() {

		style.fontSize = (state == State.LOST) ? 42 + (int) (Mathf.Cos(Time.time * 10) * 10) : 42;
		GUI.Label(new Rect(10, 10, 150, 100), "$ " + money, style);

		string text = "+ $ " + gain;
		var dim = style.CalcSize(new GUIContent(text));
		GUI.Label(new Rect(Screen.width / 2 - dim.x, gotMoneyY - dim.y / 2, 150, 100), text, moneyGainStyle);

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