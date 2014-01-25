using UnityEngine;
using System.Collections;

public class StockMarket : MonoBehaviour {

	float newX = 0;
	public float step;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		guiTexture.pixelInset = new Rect(Screen.width-256, Screen.height-116, Mathf.Min(256, (int)newX), 116);
		newX += Time.deltaTime;
	}
}
