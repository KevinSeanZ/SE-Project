using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4PortalA : MonoBehaviour {

	private Vector3 portalA_pos, portalA_rot;//, portalC_pos, portalC_rot;
	private GameObject fps;

	// Use this for initialization
	void Start () {
		//portalC_pos = new Vector3(-13F, -1F, 0F);
		//portalC_rot = new Vector3(0F, -90F, 0F);
		portalA_pos = new Vector3 (13F, -1F, 0F);
		portalA_rot = new Vector3 (0F, 90F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		fps = GameObject.Find("Room4/RigidBodyFPSController");
	}

	public void init_place(GameObject f) {
		portalA_pos.y = f.transform.localPosition.y;
		fps.transform.localPosition = portalA_pos;
	}

	void OnCollisionEnter() {
		//portalA_pos.y = fps.transform.localPosition.y;
		//fps.transform.localPosition = portalA_pos;
	}
}
