using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3PortalB : MonoBehaviour {

	private Vector3 portalD_pos, portalD_rot;
	private MeshRenderer rd;
	private GameObject fps;
	private Room3Controller r3;

	// Use this for initialization
	void Start () {
		portalD_pos = new Vector3 (0F, -1F, 13F);
		portalD_rot = new Vector3 (0F, 180F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		rd = GameObject.Find("Room3/PaintingB").GetComponent<MeshRenderer>();
		fps = GameObject.Find("Room3/RigidBodyFPSController");
		r3 = GameObject.Find("Room3").GetComponent<Room3Controller>();
	}

	public void setMaterial(Material mat) {
		rd.material = mat;
	}

	void OnCollisionEnter() {
		portalD_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalD_pos;
		r3.checkChoice(1);
	}
}
