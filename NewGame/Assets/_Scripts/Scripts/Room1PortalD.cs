using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1PortalD : MonoBehaviour {

	private GameObject room1;
	private Room1Controller controller;
	private GameObject fps;
	private Vector3 portalB_pos, portalB_rot;

	// Use this for initialization
	void Start () {
		portalB_pos = new Vector3 (0F, -1F, -13F);
		portalB_rot = new Vector3 (0F, 0F, 0F);
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
		Debug.Log("Collision Detected! With Room1 Portal D");
		portalB_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalB_pos;
		//fps.transform.localEulerAngles = portalB_rot;
		controller.checkChoice(3);
	}
}
