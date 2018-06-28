using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1PortalB : MonoBehaviour {

	private GameObject room1;
	private Room1Controller controller;
	private GameObject fps;
	private Vector3 portalD_pos, portalD_rot;

	// Use this for initialization
	void Start () {
		portalD_pos = new Vector3 (0F, -1F, 13F);
		portalD_rot = new Vector3 (0F, 180F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		room1 = GameObject.Find("Room1");
		controller = room1.GetComponent<Room1Controller>();
		fps = GameObject.Find("Room1/RigidBodyFPSController");
	}

	void OnCollisionEnter () {
		Debug.Log("Collision Detected! With Room1 Portal B");
		portalD_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalD_pos;
		//fps.transform.localEulerAngles = portalD_rot;
		controller.checkChoice(1);
	}
}
