using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4Trigger : MonoBehaviour {

	private bool ft;

	// Use this for initialization
	void Start () {
		ft = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider) {
		if (ft) {
			GameObject.Find("Room4").GetComponent<Room4Controller>().levelComplete();
			ft = false;
			//GameObject.Find("Room4/trigger").SetActive(false);
		}
	}
}
