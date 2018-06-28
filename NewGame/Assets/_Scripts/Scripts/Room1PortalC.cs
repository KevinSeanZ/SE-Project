using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1PortalC : MonoBehaviour {

	private GameObject room1;
	private Room1Controller controller;
	private GameObject fps;
	private Vector3 portalA_pos, portalA_rot;

	// Use this for initialization
	void Start () {
		portalA_pos = new Vector3 (13F, -1F, 0F);
		portalA_rot = new Vector3 (0F, -90F, 0F);
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
		Debug.Log("Collision Detected! With Room1 Portal C");
		portalA_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalA_pos;
		//fps.transform.localEulerAngles = portalA_rot;
		controller.checkChoice(2);
	}
}
