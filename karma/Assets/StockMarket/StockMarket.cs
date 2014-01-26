using UnityEngine;
using System.Collections;

public class StockMarket : MonoBehaviour {

	public float endTime;
	float newX = 0;
	float step;

	MoneyCounter mc;

	// Use this for initialization
	void Start () {
		step = 256.0f / endTime;
	}
	
	// Update is called once per frame
	void Update () {
		guiTexture.pixelInset = new Rect(Screen.width-256, Screen.height-116, Mathf.Min(256, (int)newX), 116);
		newX += Time.deltaTime * step;
	}
}
