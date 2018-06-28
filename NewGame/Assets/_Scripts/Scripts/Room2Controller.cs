using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room2Controller : MonoBehaviour {

	private GameObject fpsconstroller, fps;
	private Camera cam;
	private AudioListener audio_this;
	private GameObject maze_block;
	private int step;
	private int [] steps;
	private LightCubeController light_cube;
	private Room3Controller room3_controller;
	private Room2PortalA portalA;
	private Room2PortalB portalB;
	private Room2PortalC portalC;
	private Room2PortalD portalD;
	private bool isbegin;
	private string msg;
	private int delay, delay_lim;
	private MainCanvasSet2 ms;
	private KeyCode key;

	// Use this for initialization
	void Start () {
		fps = GameObject.Find("Room2/RigidBodyFPSController/MainCamera");

		cam = fps.GetComponent<Camera>();
		audio_this = fps.GetComponent<AudioListener>();

		cam.enabled = false;
		audio_this.enabled = false;

		fpsconstroller = GameObject.Find("Room2/RigidBodyFPSController");
		fpsconstroller.SetActive(false);

		step = 0;
		steps = new int [] {0, 1, 0, 1, 0, 1, 1, 1, 1, 2, 2, 1, 0, 0, 0};

		isbegin = true;
		msg = "地上这么大一幅图是这部分迷宫的地图吗？太好了，而且似乎头顶红色的方块也与地图有些联系。";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		if (ms)
			delay = ms.delay;
		if (!isbegin) {
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg)
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				ms.delay = 0;
				isbegin = true;
			}
		}
	}

	public void startLevel(GameObject f) {
		fpsconstroller.SetActive(true);
		cam.enabled = true;
		audio_this.enabled = true; 
		
		room3_controller = GameObject.Find("Room3").GetComponent<Room3Controller>();

		maze_block = GameObject.Find("Room2/MazeCube");	
		maze_block.SetActive(true);

		portalA = GameObject.Find("Room2/PortalA").GetComponent<Room2PortalA>();
		portalB = GameObject.Find("Room2/PortalB").GetComponent<Room2PortalB>();
		portalC = GameObject.Find("Room2/PortalC").GetComponent<Room2PortalC>();
		portalD = GameObject.Find("Room2/PortalD").GetComponent<Room2PortalD>();

		light_cube = GameObject.Find("Room2/LightCube").GetComponent<LightCubeController>();
		light_cube.setMaterial(1);
		
		portalA.init();
		portalB.init();
		portalC.init();
		portalD.init();

		//Debug.Log(f.transform.localPosition.y);
		portalA.init_place(f);

		isbegin = false;

		ms = GameObject.Find("MainCanvas").GetComponent<MainCanvasSet2>();
		delay_lim = ms.delay_lim;

		key = ms.key;
	}

	public void checkChoice(int choice) {
		if (choice == steps[step]) {
			step += 1;
			if (step == steps.Length)  {
				nextLevel();
				return;
			} 
		} else {
			step = 0;
		}

		Debug.Log("choice:"+choice.ToString()+" step:"+step.ToString()+" nextdir:"+steps[step].ToString());

		if (step == 0) {
			maze_block.SetActive(true);
			light_cube.setMaterial(1);
		} else if (step == 6) {
			maze_block.SetActive(true);
			light_cube.setMaterial(2);
		} else {
			if (step == 14) {
				light_cube.setMaterial(3);
			}
			maze_block.SetActive(false);
		}
	}

	private void nextLevel() {
		cam.enabled = false;
		audio_this.enabled = false;
		fpsconstroller.SetActive(false);
		room3_controller.startLevel(fpsconstroller);
	}
}
