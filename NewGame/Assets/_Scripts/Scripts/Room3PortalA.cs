using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3PortalA : MonoBehaviour {

	private Vector3 portalC_pos, portalC_rot;
	private MeshRenderer rd;
	private GameObject fps;
	private Room3Controller r3;

	// Use this for initialization
	void Start () {
		portalC_pos = new Vector3(-13F, -1F, 0F);
		portalC_rot = new Vector3(0F, 90F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init() {
		rd = GameObject.Find("Room3/PaintingA").GetComponent<MeshRenderer>();
		fps = GameObject.Find("Room3/RigidBodyFPSController");
		r3 = GameObject.Find("Room3").GetComponent<Room3Controller>();
	}

	public void setMaterial(Material mat) {
		rd.material = mat;
	}

	public void init_place (GameObject f) {
		portalC_pos.y = f.transform.localPosition.y;
		fps.transform.localPosition = portalC_pos;
		Debug.Log(fps.transform.localPosition.ToString());
		//fps.transform.localEulerAngles = portalC_rot;
	}

	void OnCollisionEnter() {
		portalC_pos.y = fps.transform.localPosition.y;
		fps.transform.localPosition = portalC_pos;
		r3.checkChoice(0);
	}
}
