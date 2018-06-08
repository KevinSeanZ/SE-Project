using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserveButtonBehavior : MonoBehaviour {

	public bool isTrigger = false;
	private PlayerController3 triggercontroller;
    //private GameObject fpsc3;
	private GameObject observebutton;

	// Use this for initialization
	void Start () {
        triggercontroller = GameObject.Find("FPSController3").GetComponent<PlayerController3>();
        //fpsc3 = GameObject.Find("FPSController3");
		observebutton = GameObject.Find("level1s3/Canvas/observeDiaryButton");
        GameObject.Find("FPSController3").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		/*isTrigger = triggercontroller.istrigger2;
        
        if (isTrigger) {
			observebutton.SetActive(true);
		} else {
			observebutton.SetActive(false);
		}*/
	}
}
