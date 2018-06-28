using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3PortalC : MonoBehaviour {

	// Use this for initialization
	private Vector3 portalA_pos, portalA_rot;
	private MeshRenderer rd;
	private GameObject fps;
	private Room3Controller r3;

	// Use this for initialization
	void Start () {
		portalA_pos = new Vector3 (13F, -1F, 0F);
		portalA_rot = new Vector3 (0F, -90F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		rd = GameObject.Find("Room3/PaintingC").GetComponent<MeshRenderer>();
		fps = GameObject.Find("Room3/RigidBodyFPSController");
		r3 = GameObject.Find("Room3").GetComponent<Room3Controller>();
	}

	public void setMaterial(Material mat) {
		rd.material = mat;
	}

	void OnCollisionEnter () {
		portalA_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalA_pos;
		r3.checkChoice(2);
	}
}
