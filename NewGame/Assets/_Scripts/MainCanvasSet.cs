using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvasSet : MonoBehaviour {
    private bool ismainCam = true;
    private bool isbegin = false;
    private bool isBag = false;
    private GameObject mainCamera;
    private GameObject diaryCamera;
    private GameObject observeCamera;
    private GameObject S3Camera;
    private GameObject trigger1;
    private Canvas codeboxCanvas;
    //private float timer = 0.0f;
    public GameObject fps1;
    public GameObject fps2;
    private ClickBox codebox;
    private bool levelclear;
    //public GameObject problemcacnvas;
    public int m_millisecond;
    public int m_second;
    public int m_minute;
    public int m_hour;
    public Texture []bag_item;
    [HideInInspector]
    public bool istalking = false;
    // Use this for initialization

    

    void Start () {
        //problemcacnvas = GameObject.Find("level1s3/Canvas");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        observeCamera = GameObject.FindGameObjectWithTag("ObserveCamera");
        S3Camera = GameObject.FindGameObjectWithTag("MainCamera1");
        diaryCamera = GameObject.Find("level1s3/observeDiaryCamera");
        codeboxCanvas = GameObject.Find("CodeBox/Canvas").GetComponent<Canvas>();
        trigger1 = GameObject.FindGameObjectWithTag("TriggerArea1");
        //problemcacnvas.SetActive(false);

        codebox = GameObject.Find("CodeBox/Canvas").GetComponent<ClickBox>();
        observeCamera.GetComponent<AudioListener>().enabled = false;
        observeCamera.GetComponent<Camera>().enabled = false;
        S3Camera.GetComponent<AudioListener>().enabled = false;
        S3Camera.GetComponent<Camera>().enabled = false;

        fps2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        ismainCam = mainCamera.GetComponent<Camera>().isActiveAndEnabled;
        //timer += Time.deltaTime;
        levelclear = codebox.levelclear;
        if (m_hour >= 0 && m_minute >= 0 && m_second >= 0 && m_millisecond >= 0 && isbegin)
            m_millisecond -= (int)(Time.deltaTime*1000);
        if (m_millisecond < 0) { m_millisecond += 1000; m_second -= 1;}
        if (m_second < 0) { m_second += 60; m_minute -= 1; }
        if (m_minute < 0) { m_minute += 60; m_hour -= 1; }
        

        
	}

    void ChangeTime(float m)
    {
        int totaltime = m_hour * 3600000 + m_minute * 60000 + m_second *1000 + m_millisecond;
        totaltime = (int)(Mathf.Round((float)((double)(totaltime)*m)));
        m_millisecond = totaltime % 1000;
        m_second = totaltime / 1000 % 60;
        m_minute = totaltime / 1000 / 60 % 60;
        m_hour = totaltime / 1000 / 60 / 60;
        
    }

    void OnGUI()
    {
        //GUI.Button(new Rect(Screen.width - 60, 10 ,50 , 50), "timer");
        
        string remaintime;
        if (m_hour >= 0 && m_minute >= 0 && m_second >= 0 && m_millisecond >= 0)
            remaintime = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", m_hour, m_minute, m_second, m_millisecond);
        else remaintime = "时间到了！";
        GUI.TextArea(new Rect(Screen.width - 100, 10, 90, 30), remaintime);
        if (levelclear)
        {
            GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), "我：\n 谢天谢地，门开了。");
            
        }
        //only save progress at start
        if (!isbegin)
            if (GUI.Button(new Rect(Screen.width - 160, 10, 50, 50),"Save"))
            {
                Debug.Log("Save");
            }
        //-----------------------------------------------------------------
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
                
                fps1.SetActive(false);
                fps2.SetActive(true);
                diaryCamera.SetActive(false);
                
                S3Camera.SetActive(true);
                S3Camera.GetComponent<AudioListener>().enabled = true;
                S3Camera.GetComponent<Camera>().enabled = true;
                //mainCamera.SetActive(false);
                mainCamera.GetComponent<AudioListener>().enabled = false;
                mainCamera.GetComponent<Camera>().enabled = false;

                
                ChangeTime(15f);
                
            }
            if (GUI.Button(new Rect(70, 10, 50, 50), "Bag"))
            {
                Debug.Log("bag");
                isBag = isBag ? false : true;

            }
            if (GUI.Button(new Rect(130,10,50,50),"Back"))
            {
                SceneManager.LoadScene("StartScene");
            }
        }
        else if (observeCamera.GetComponent<Camera>().enabled)
        {
            if (GUI.Button(new Rect(10, 10, 50, 50), "Return"))
            {
                Debug.Log("return");
                observeCamera.GetComponent<AudioListener>().enabled = false;
                observeCamera.GetComponent<Camera>().enabled = false;
                mainCamera.GetComponent<AudioListener>().enabled = true;
                mainCamera.GetComponent<Camera>().enabled = true;
                fps1.SetActive(true);
                //problemcacnvas.SetActive(false);
                codeboxCanvas.worldCamera = mainCamera.GetComponent<Camera>();
            }
        }
        else if(S3Camera.GetComponent<Camera>().enabled)
        {
           
            if (GUI.Button(new Rect(10, 10, 50, 50), "Cross!"))
            {
                Debug.Log("Next Scene");
                fps1.SetActive(true);
                fps2.SetActive(false);
                S3Camera.GetComponent<AudioListener>().enabled = false;
                S3Camera.GetComponent<Camera>().enabled = false;
                mainCamera.GetComponent<AudioListener>().enabled = true;
                mainCamera.GetComponent<Camera>().enabled = true;
                
                

                ChangeTime(1f/15f);

            }
            if (GUI.Button(new Rect(70, 10, 50, 50), "Bag"))
            {
                Debug.Log("bag");
                isBag = isBag?false:true;
            }
            if (GUI.Button(new Rect(130, 10, 50, 50), "Back"))
            {
                SceneManager.LoadScene("StartScene");
            }
        }
        else if (diaryCamera.GetComponent<Camera>().enabled)
        {
            if (GUI.Button(new Rect(10, 10, 50, 50), "Return"))
            {
                Debug.Log("return");
                diaryCamera.GetComponent<AudioListener>().enabled = false;
                diaryCamera.GetComponent<Camera>().enabled = false;
                diaryCamera.SetActive(false);
                S3Camera.GetComponent<AudioListener>().enabled = true;
                S3Camera.GetComponent<Camera>().enabled = true;
                S3Camera.SetActive(true);
                fps2.SetActive(true);

                //codeboxCanvas.worldCamera = mainCamera.GetComponent<Camera>();
            }
        }
        
        if (isBag)  ShowBag();
        
    }

    void ShowBag()
    {
        float w = Screen.width / 9;
        for (int i = 0; i < 5; i++)
        {
            Rect TextureRect = new Rect((i + 2) * w, Screen.height - 2 * w, w, w);
            if (bag_item[i]) GUI.DrawTexture(TextureRect, bag_item[i]);
            if (GUI.Button(TextureRect, ""))
            {
                //Debug.Log(i + "th button!");
                if (bag_item[i]) Debug.Log(bag_item[i].name);
                isBag = false;
            }
        }
    }
    
}
