using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room4Controller : MonoBehaviour {

	private GameObject fps, fps_controller;
	private Camera cam;
	private AudioListener audio_this;
	private GameObject portalC, portalA;
	private Room4PortalA pa;
	private Room4PortalC pc;
	private string msg, msg1, msg2;
	private bool isbegin, showmsg1, iscomplete;
	private GameObject comic;
	public float rotateSpeed;
	private int delay, delay_lim;
	private MainCanvasSet2 ms;
	private KeyCode key;

	// Use this for initialization
	void Start () {
		fps = GameObject.Find("Room4/RigidBodyFPSController/MainCamera");
		fps_controller = GameObject.Find("Room4/RigidBodyFPSController");
		cam = fps.GetComponent<Camera>();
		audio_this = fps.GetComponent<AudioListener>();

		cam.enabled = false;
		audio_this.enabled = false;
		fps_controller.SetActive(false);

		showmsg1 = true;
		isbegin = true;
		iscomplete = false;
		msg = "那不是我的漫画书吗？？！！";
		msg1 = "太棒了！我终于拿到了漫画书，哪怕是在精神世界里。。。";
		msg2 = "第二关已完成";
	}
	
	// Update is called once per frame
	void Update () {
		if (!comic) {
			comic = GameObject.Find("Room4/comic");
		}
		comic.transform.Rotate(Vector3.up * rotateSpeed);
	}

	void OnGUI () {
		if (ms)
			delay = ms.delay;
		if (!isbegin) {
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg)
				|| (Input.GetKeyDown(key) && delay > delay_lim )) {
				ms.delay = 0;
				isbegin = true;
			}
		}

		if (iscomplete) {
			string msg_;
			msg_ = (showmsg1)? msg1 : msg2;
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg_)
				|| (Input.GetKeyDown(key) && delay > delay_lim )) {
				ms.delay = 0;
				if (showmsg1) {
					showmsg1 = false;
				} else {
					iscomplete = false;
				}
			}
		}
	}

	public void startLevel(GameObject f) {
		fps_controller.SetActive(true);
		cam.enabled = true;
		audio_this.enabled = true;

		portalA = GameObject.Find("Room4/PortalA");
		pa = portalA.GetComponent<Room4PortalA>();
		portalC = GameObject.Find("Room4/PortalC");
		pc = portalC.GetComponent<Room4PortalC>();
	
		pa.init();
		pc.init();
		
		pa.init_place(f);

		portalC.SetActive(false);
		portalA.SetActive(false);

		isbegin = false;

		ms = GameObject.Find("MainCanvas").GetComponent<MainCanvasSet2>();
		delay_lim = ms.delay_lim;
		key = ms.key;
	}

	public void levelComplete() {
		iscomplete = true;
	}
}
