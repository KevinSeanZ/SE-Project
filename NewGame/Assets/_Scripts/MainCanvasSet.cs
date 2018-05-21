using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasSet : MonoBehaviour {
    private bool ismainCam = true;
    private bool isbegin = false;
    private GameObject mainCamera;
    private GameObject observeCamera;
    private GameObject trigger1;
    private Canvas codeboxCanvas;
    //private float timer = 0.0f;

    public int m_millisecond;
    public int m_second;
    public int m_minute;
    public int m_hour;

    public bool istalking = false;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        observeCamera = GameObject.FindGameObjectWithTag("ObserveCamera");
        codeboxCanvas = GameObject.Find("CodeBox/Canvas").GetComponent<Canvas>();
        trigger1 = GameObject.FindGameObjectWithTag("TriggerArea1");
    }
	
	// Update is called once per frame
	void Update () {
        ismainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().isActiveAndEnabled;
        //timer += Time.deltaTime;
        
        if (m_hour >= 0 && m_minute >= 0 && m_second >= 0 && m_millisecond >= 0 && isbegin)
            m_millisecond -= (int)(Time.deltaTime*1000);
        if (m_millisecond < 0) { m_millisecond += 1000; m_second -= 1;}
        if (m_second < 0) { m_second += 60; m_minute -= 1; }
        if (m_minute < 0) { m_minute += 60; m_hour -= 1; }
        
	}

    void OnGUI()
    {
        //GUI.Button(new Rect(Screen.width - 60, 10 ,50 , 50), "timer");
        string remaintime;
        if (m_hour >= 0 && m_minute >= 0 && m_second >= 0 && m_millisecond >= 0)
            remaintime = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", m_hour, m_minute, m_second, m_millisecond);
        else remaintime = "时间到了！";
        GUI.TextArea(new Rect(Screen.width - 100, 7, 90, 30), remaintime);
        if (!trigger1.gameObject.activeSelf && !isbegin)
        {
            istalking = true;
            if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), "我：\n 门外好像有人在开门，直觉告诉我" +
                "他不是什么好人，可能就是把我关在这里的家伙。我得赶快想办法出去。"))
            {
                isbegin = true;
                istalking = false;
            }

        }
        

        if (ismainCam)
        {
            if (GUI.Button(new Rect(10, 10, 50, 50), "Cross!"))
            {
                Debug.Log("Next Scene");
            }
            if (GUI.Button(new Rect(70, 10, 50, 50), "Bag"))
            {
                Debug.Log("bag");
            }
        }
        else
        {
            if (GUI.Button(new Rect(10, 10, 50, 50), "Return"))
            {
                Debug.Log("return");
                observeCamera.GetComponent<AudioListener>().enabled = false;
                observeCamera.GetComponent<Camera>().enabled = false;
                mainCamera.GetComponent<AudioListener>().enabled = true;
                mainCamera.GetComponent<Camera>().enabled = true;
                codeboxCanvas.worldCamera = mainCamera.GetComponent<Camera>();
            }
        }
    }

    
}
