using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObserveDiary : MonoBehaviour {

	private GameObject observecam;

	public void Start() {
		observecam = GameObject.Find("observeDiaryCamera");
	}
	public void Update() {

	}

	public void Click_test() {
		Debug.Log("observe diary");

        GameObject fps = GameObject.Find("FPSController3/FirstPersonCharacter");

		fps.GetComponent<AudioListener>().enabled = false;
        fps.GetComponent<Camera>().enabled = false;
		fps.SetActive(false);
		
		observecam.GetComponent<AudioListener>().enabled = true;
        observecam.GetComponent<Camera>().enabled = true;
        observecam.SetActive(true);
	}
}
