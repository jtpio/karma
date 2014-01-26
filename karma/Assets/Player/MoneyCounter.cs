using UnityEngine;
using System.Collections;

public class MoneyCounter : MonoBehaviour {

	public int moneyStart;
	public int moneyEnd;
	public int realMoneyEnd;
	public int endTime;
	public string lostText;
	public string goalString;
	public GUIStyle style;
	public GUIStyle moneyGainStyle;
	public GUIStyle lostStyle;
	public GUIStyle goalStyle;
	
	Hashtable htGotMoneyIn;
	Hashtable htGotMoneyOut;

	float loseTime;
	int moneyOffset = 1000000;
	int gain = 0;
	float gotMoneyY = -70.0f;
	public static float time;

	int money;
	public enum State{
		COLLECT, LOSING, LOST
	}
	public static State state;

	void Start () {
		time = 0;
		money = moneyStart;
		moneyEnd += moneyOffset;
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
		time += Time.deltaTime;

		loseTime = (220.0f/256.0f) * endTime;

		if (state == State.COLLECT && time > loseTime) {

			if (state == State.COLLECT && money < realMoneyEnd) {
				realMoneyEnd = money / 3;
			}
			state = State.LOSING;
		}

		if (state == State.LOSING) {
			money -= (int)((money - realMoneyEnd) / 30.0f);
		}

		if (time > endTime) state = State.LOST;
	}

	void RaiseGain(float v) {
		gotMoneyY = v;
	}

	void GainUpStop() {
		iTween.ValueTo(gameObject, htGotMoneyOut);
	}

	public void incMoney() {
		gain = 0;
		if (state == State.COLLECT) {
			//gain = (int) Mathf.Max(0, (moneyEnd - money) / 30.0f);
			gain = (int) (time * 20000);
		}
		money += gain;
		StopTweens();
		iTween.ValueTo(gameObject, htGotMoneyIn);
		
	}

	void StopTweens() {
		iTween.StopByName("moneyIn");
		iTween.StopByName("moneyOut");
	}

	string formatMoney(int tmp) {
		if (tmp == 0) return "0";
		string ans = "";
		int c = 0;
		while (tmp != 0) {
			c++;
			ans = (tmp % 10) + ans;
			tmp /= 10;
			if (c == 3 && tmp != 0) {
				ans = "," + ans;
				c = 0;
			}
		}
		return "$ " + ans;
	}

	public void OnGUI() {

		GUI.Label(new Rect(10, 10, 150, 100),  goalString, goalStyle);

		var d = style.CalcSize(new GUIContent(goalString));
		GUI.Label(new Rect(10, 10 + d.y + 10, 150, 100), formatMoney(money), style);

		string text = "+ " + formatMoney(gain);
		var dim = style.CalcSize(new GUIContent(text));
		GUI.Label(new Rect(Screen.width / 2 - dim.x, gotMoneyY - dim.y / 2, 150, 100), text, moneyGainStyle);

		if (state == State.LOST) {
			if (Input.GetKey(KeyCode.R)) {
				Application.LoadLevel(0);
			}
		} else if (state == State.LOSING) {
			var d2 = style.CalcSize(new GUIContent(lostText));
			GUI.Label(new Rect(Screen.width / 2 - d2.x / 2, Screen.height / 2 - d2.y / 2, 300, 300), lostText, lostStyle);
		}
	}
}