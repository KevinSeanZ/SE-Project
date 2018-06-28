using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2PortalD : MonoBehaviour {

	private Vector3 portalB_pos, portalB_rot;
	private GameObject fps;
	private Room2Controller room2_controller;

	// Use this for initialization
	void Start () {
		portalB_pos = new Vector3 (0F, -1F, -13F);
		portalB_rot = new Vector3 (0F, 0F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		fps = GameObject.Find("Room2/RigidBodyFPSController");
		room2_controller = GameObject.Find("Room2").GetComponent<Room2Controller>();
	}

	void OnCollisionEnter() {
		portalB_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalB_pos;
		//fps.transform.localEulerAngles = portalB_rot;
		room2_controller.checkChoice(3);
	}
}
