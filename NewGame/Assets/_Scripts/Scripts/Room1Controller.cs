using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Controller : MonoBehaviour {

	private int next_step;
	private int correctSteps;
	private int maxSteps;
	private GameObject fpscontroller, fps_top;
	private Camera cam;
	private AudioListener audio;
	private GameObject spot_light;
	private Vector3 [] positions, rotations;
	private Room2Controller room2_controller;
	private Room1PortalA pa;
	private Room1PortalB pb;
	private Room1PortalC pc;
	private Room1PortalD pd;

	// Use this for initialization
	void Start () {
		correctSteps = 0;
		maxSteps = 5;

		fpscontroller = GameObject.Find("Room1/RigidBodyFPSController/MainCamera");
		fps_top = GameObject.Find("Room1/RigidBodyFPSController");
		cam = fpscontroller.GetComponent<Camera>();
		audio = fpscontroller.GetComponent<AudioListener>();
		
		
		cam.enabled = false;
		audio.enabled = false;
		fps_top.SetActive(false);
		

		positions = new Vector3 [4];
		rotations = new Vector3 [4];

		// A-0, B-1, C-2, D-3

		positions[0] = new Vector3(0.3F, 2.33F, 0F);
		rotations[0] = new Vector3(60F, -90F, 0F);

		positions[1] = new Vector3(0F, 2.33F, -0.3F);
		rotations[1] = new Vector3(60F, 0F, 0F);

		positions[2] = new Vector3(-0.3F, 2.33F, 0F);
		rotations[2] = new Vector3(60F, 90F, 0F);

		positions[3] = new Vector3(0F, 2.33F, 0.3F);
		rotations[3] = new Vector3(60F, 180F, 0F);
	}

	void Awake() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startLevel() {
		GameObject.Find("MainCanvas").GetComponent<MainCanvasSet2>().level3begin = false;

		fps_top.SetActive(true);
		cam.enabled = true;
		audio.enabled = true;

		spot_light = GameObject.Find("Room1/SpotLight");
		room2_controller = GameObject.Find("Room2").GetComponent<Room2Controller>();

		pa = GameObject.Find("Room1/PortalA").GetComponent<Room1PortalA>();
		pb = GameObject.Find("Room1/PortalB").GetComponent<Room1PortalB>();
		pc = GameObject.Find("Room1/PortalC").GetComponent<Room1PortalC>();
		pd = GameObject.Find("Room1/PortalD").GetComponent<Room1PortalD>();

		pa.init();
		pb.init();
		pc.init();
		pd.init();

		generateNextStep();
	}

	private void generateNextStep() {
		next_step = (int)Random.Range(0, 4);
		Debug.Log("next step is " + next_step.ToString());
		spot_light.transform.localPosition = positions[next_step];
		spot_light.transform.localEulerAngles = rotations[next_step];
	}

	private void nextLevel() {
		cam.enabled = false;
		audio.enabled = false;
		fps_top.SetActive(false);

		Debug.Log("Room1 to Room2");

		room2_controller.startLevel(fps_top);
	}

	public void checkChoice(int choice) {
		if (choice == next_step) {
			correctSteps += 1;
			if (correctSteps == maxSteps) {
				nextLevel();
			} else {
				generateNextStep();
			}
		} else {
			correctSteps = 0;
			generateNextStep();
		}
	}
}
