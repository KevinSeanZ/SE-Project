using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {
	public Button aclkBt;
	public Button clkBt;
	public GameObject ball1;
	public GameObject ball2;
	public GameObject ball3;
	// Use this for initialization
	void Start () {
		aclkBt.onClick.AddListener (AntiClock);
		clkBt.onClick.AddListener (Clock);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void AntiClock()
	{
		transform.RotateAround (this.transform.position,Vector3.up, -120f);
		ball1.transform.RotateAround (this.transform.position,Vector3.up, -120f);
		ball2.transform.RotateAround (this.transform.position,Vector3.up, -120f);
		ball3.transform.RotateAround (this.transform.position,Vector3.up, -120f);
	}

	void Clock()
	{
		transform.RotateAround (this.transform.position,Vector3.up , 120f);
		ball1.transform.RotateAround (this.transform.position,Vector3.up, 120f);
		ball2.transform.RotateAround (this.transform.position,Vector3.up, 120f);
		ball3.transform.RotateAround (this.transform.position,Vector3.up, 120f);
	}
}
