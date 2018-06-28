using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tragger : MonoBehaviour
{
    public bool isTraggered = false;
    public string fragment_name;
    private Button btn1, btn2, btn3, btn4;
    private GameObject fps, fps_controller;
    private Camera cam;
    private AudioListener audio_this;
    private int cnt;
    private Room1Controller r1;
    private MainCanvasSet2 ms;
    public MainCanvasSet2 mcs2;
    public Texture picture1;
	public Texture picture2;
	public Texture picture3;
	public Texture picture4;

    // Use this for initialization
    void Start()
    {
        btn1 = GameObject.Find("Canvas01/Button").GetComponent<Button>();
        btn2 = GameObject.Find("Canvas02/Button").GetComponent<Button>();
        btn3 = GameObject.Find("Canvas03/Button").GetComponent<Button>();
        btn4 = GameObject.Find("Canvas04/Button").GetComponent<Button>();
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
        btn1.onClick.AddListener(pick1);
        btn2.onClick.AddListener(pick2);
        btn3.onClick.AddListener(pick3);
        btn4.onClick.AddListener(pick4);

        fps_controller = gameObject;
        fps = GameObject.Find("RigidBodyFPSController/MainCamera");
        cam = fps.GetComponent<Camera>();
        audio_this = fps.GetComponent<AudioListener>();

        fps_controller.SetActive(true);
        cam.enabled = true;
        audio_this.enabled = true;

        cnt = 0;
        
        r1 = GameObject.Find("Room1").GetComponent<Room1Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "tragger01")
            btn1.gameObject.SetActive(true);
        else if (collider.tag == "tragger02")
            btn2.gameObject.SetActive(true);
        else if (collider.tag == "tragger03")
            btn3.gameObject.SetActive(true);
        else if (collider.tag == "tragger04")
            btn4.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "tragger01")
            btn1.gameObject.SetActive(false);
        else if (collider.tag == "tragger02")
            btn2.gameObject.SetActive(false);
        else if (collider.tag == "tragger03")
            btn3.gameObject.SetActive(false);
        else if (collider.tag == "tragger04")
            btn4.gameObject.SetActive(false);
    }

    public void nextLevel() {
        cam.enabled = false;
        audio_this.enabled = false;
        fps_controller.SetActive(false);

        r1.startLevel();
    }

    private void checkCnt () {
        if (!ms) {
            ms = GameObject.Find("MainCanvas").GetComponent<MainCanvasSet2>();
        }
        if (cnt == 4) {
            ms.level2end = false;
            ms.showmsg6 = true;
        } else {
            ms.ispick = false;
        }
    }

    void pick1()
    {
        GameObject.Find("fragment01").SetActive(false);
        fragment_name = "fragment1";
        GameObject.Find("tragger01").SetActive(false);
        btn1.gameObject.SetActive(false);
        mcs2.bag_item[mcs2.currentlen] = picture1;
        mcs2.currentlen ++;
        cnt += 1;
        checkCnt();
    }

    void pick2()
    {
        GameObject.Find("fragment02").SetActive(false);
        fragment_name = "fragment2";
        GameObject.Find("tragger02").SetActive(false);
        btn2.gameObject.SetActive(false);
        mcs2.bag_item[mcs2.currentlen] = picture2;
        mcs2.currentlen ++;
        cnt += 1;
        checkCnt();
    }
    void pick3()
    {
        GameObject.Find("fragment03").SetActive(false);
        fragment_name = "fragment3";
        GameObject.Find("tragger03").SetActive(false);
        btn3.gameObject.SetActive(false);
        cnt += 1;
        mcs2.bag_item[mcs2.currentlen] = picture3;
        mcs2.currentlen ++;
        
        checkCnt();
    }
    void pick4()
    {
        GameObject.Find("fragment04").SetActive(false);
        fragment_name = "fragment4";
        GameObject.Find("tragger04").SetActive(false);
        btn4.gameObject.SetActive(false);
        mcs2.bag_item[mcs2.currentlen] = picture4;
        mcs2.currentlen ++;
        cnt += 1;
        checkCnt();
    }
}
