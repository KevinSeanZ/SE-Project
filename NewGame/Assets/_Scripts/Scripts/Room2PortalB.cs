using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2PortalB : MonoBehaviour {

	private Vector3 portalD_pos, portalD_rot;
	private GameObject fps;
	private Room2Controller room2_controller;

	// Use this for initialization
	void Start () {
		portalD_pos = new Vector3 (0F, -1F, 13F);
		portalD_rot = new Vector3 (0F, 180F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		fps = GameObject.Find("Room2/RigidBodyFPSController");
		room2_controller = GameObject.Find("Room2").GetComponent<Room2Controller>();
	}

	void OnCollisionEnter() {
		portalD_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalD_pos;
		//fps.transform.localEulerAngles = portalD_rot;
		room2_controller.checkChoice(1);
	}
}
