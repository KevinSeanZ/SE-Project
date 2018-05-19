using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateBall : MonoBehaviour {
	public Button aclkBt;
	public Button clkBt;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		aclkBt.onClick.AddListener (AntiClock);
		clkBt.onClick.AddListener (Clock);
	}

	void AntiClock()
	{
		transform.RotateAround (new Vector3 (0f, 0f, 0f), Vector3.up, 120f);
	}

	void Clock()
	{
		transform.RotateAround (new Vector3 (0f, 0f, 0f), Vector3.up , -120f);
	}
}
