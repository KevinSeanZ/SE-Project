using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room3Controller : MonoBehaviour {

	private GameObject fps, fps_controller;
	private Camera cam;
	private AudioListener audio_this;
	public Material r3_s1_pic1, r3_s1_pic2, r3_s2_pic1, r3_s2_pic2, r3_s3_pic1, 
			r3_s3_pic2, r3_s4_pic1, r3_s4_pic2;
	private int correctIndex, correctSteps, maxSteps;
	private Room3PortalA pa;
	private Room3PortalB pb;
	private Room3PortalC pc;
	private Room3PortalD pd;
	private Room4Controller r4;
	private bool isbegin;
	private string msg;
	private int delay, delay_lim;
	private MainCanvasSet2 ms;
	private KeyCode key;

	// Use this for initialization
	void Start () {
		fps = GameObject.Find("Room3/RigidBodyFPSController/MainCamera");
		fps_controller = GameObject.Find("Room3/RigidBodyFPSController");
		cam = fps.GetComponent<Camera>();
		audio_this = fps.GetComponent<AudioListener>();

		cam.enabled = false;
		audio_this.enabled = false;
		fps_controller.SetActive(false);

		correctSteps = 0;
		maxSteps =  4; // 4

		isbegin = true;
		msg = "又换什么花样了？这几幅图能告诉我什么信息呢？";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startLevel(GameObject f) {
		fps_controller.SetActive(true);
		cam.enabled = true;
		audio_this.enabled = true;

		pa = GameObject.Find("Room3/PortalA").GetComponent<Room3PortalA>();
		pb = GameObject.Find("Room3/PortalB").GetComponent<Room3PortalB>();
		pc = GameObject.Find("Room3/PortalC").GetComponent<Room3PortalC>();
		pd = GameObject.Find("Room3/PortalD").GetComponent<Room3PortalD>();

		pa.init();
		pb.init();
		pc.init();
		pd.init();

		generateStep();

		pa.init_place(f);

		isbegin = false;

		ms = GameObject.Find("MainCanvas").GetComponent<MainCanvasSet2>();
		delay_lim = ms.delay_lim;
		key = ms.key;
	}

	void OnGUI () {
		if (ms)
			delay = ms.delay;
		if (!isbegin) {
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg)
				|| (Input.GetKeyDown(key) && delay > delay_lim) ) {
				ms.delay = 0;
				isbegin = true;
			}
		}
	}

	private void nextLevel() {
		r4 = GameObject.Find("Room4").GetComponent<Room4Controller>();
		cam.enabled = false;
		audio_this.enabled = false;
		fps_controller.SetActive(false);
		r4.startLevel(fps_controller);
	}

	private void sendStep() {
		Material mat3, mat1;
		mat3 = r3_s1_pic1;
		mat1 = r3_s1_pic2;
		switch(correctSteps) {
		case 0:
			mat3 = r3_s1_pic1;
			mat1 = r3_s1_pic2;
			break;
		case 1:
			mat3 = r3_s2_pic1;
			mat1 = r3_s2_pic2;
			break;
		case 2:
			mat3 = r3_s3_pic1;
			mat1 = r3_s3_pic2;
			break;
		case 3:
			mat3 = r3_s4_pic1;
			mat1 = r3_s4_pic2;
			break;
		}
		
		pa.setMaterial(mat3);
		pb.setMaterial(mat3);
		pc.setMaterial(mat3);
		pd.setMaterial(mat3);

		switch (correctIndex) {
		case 0:
			pa.setMaterial(mat1);
			break;
		case 1:
			pb.setMaterial(mat1);
			break;
		case 2:
			pc.setMaterial(mat1);
			break;
		case 3:
			pd.setMaterial(mat1);
			break;
		}
	}

	private void generateStep() {
		correctIndex = (int)Random.Range(0F, 4F);
		sendStep();
	}

	public void checkChoice (int choice) {
		if (choice == correctIndex) {
			correctSteps += 1;
			if (correctSteps == maxSteps) {
				nextLevel();
				return;
			}
		} else {
			correctSteps = 0;
		}
		generateStep();
		Debug.Log("correctSteps = " + correctSteps.ToString() +
				 " and correctIndex = " + correctIndex.ToString());
	}
}
