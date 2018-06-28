using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3PortalD : MonoBehaviour {

	private Vector3 portalB_pos, portalB_rot;
	private MeshRenderer rd;
	private GameObject fps;
	private Room3Controller r3;

	// Use this for initialization
	void Start () {
		portalB_pos = new Vector3 (0F, -1F, -13F);
		portalB_rot = new Vector3 (0F, 0F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		rd = GameObject.Find("Room3/PaintingD").GetComponent<MeshRenderer>();
		fps = GameObject.Find("Room3/RigidBodyFPSController");
		r3 = GameObject.Find("Room3").GetComponent<Room3Controller>();
	}

	public void setMaterial(Material mat) {
		rd.material = mat;
	}

	void OnCollisionEnter() {
		portalB_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalB_pos;
		r3.checkChoice(3);
	}
}
