using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2PortalA : MonoBehaviour {

	private Vector3 portalC_pos, portalC_rot;
	private GameObject fps;
	private Room2Controller room2_controller;

	// Use this for initialization
	void Start () {
		portalC_pos = new Vector3(-13F, -1F, 0F);
		portalC_rot = new Vector3(0F, 90F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		fps = GameObject.Find("Room2/RigidBodyFPSController");
		room2_controller = GameObject.Find("Room2").GetComponent<Room2Controller>();
	}

	public void init_place(GameObject f) {
		//Debug.Log(f.transform.localPosition.y.ToString());
		portalC_pos.y = f.transform.localPosition.y;
		fps.transform.localPosition = portalC_pos;
		//fps.transform.localEulerAngles = portalC_rot;
		//Debug.Log(fps.transform.localEulerAngles.y);
	}

	void OnCollisionEnter() {
		portalC_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalC_pos;
		//fps.transform.localEulerAngles = portalC_rot;
		room2_controller.checkChoice(0);
	}
}
