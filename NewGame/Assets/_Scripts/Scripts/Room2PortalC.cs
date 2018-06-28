using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2PortalC : MonoBehaviour {

	private Vector3 portalA_pos, portalA_rot;
	private GameObject fps;
	private Room2Controller room2_controller;

	// Use this for initialization
	void Start () {
		portalA_pos = new Vector3 (13F, -1F, 0F);
		portalA_rot = new Vector3 (0F, -90F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		fps = GameObject.Find("Room2/RigidBodyFPSController");
		room2_controller = GameObject.Find("Room2").GetComponent<Room2Controller>();
	}

	void OnCollisionEnter() {
		portalA_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalA_pos;
		//fps.transform.localEulerAngles = portalA_rot;
		room2_controller.checkChoice(2);
	}
}
