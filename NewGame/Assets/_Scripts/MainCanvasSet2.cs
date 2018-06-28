using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCanvasSet2: MonoBehaviour {

	public int m_millisecond;
    public int m_second;
    public int m_minute;
    public int m_hour;
	private bool isbegin, isBag, istalking, showmsg1;
	[HideInInspector]
	public bool level2begin, level2end, level3begin;//, level3end;
	public int level;
	[HideInInspector]
	public Texture [] bag_item;
	[HideInInspector]
	public int currentlen = 0;

	

	private string msg1, msg2, msg3, msg4, msg5, msg6, msg7, msg8, msg9, msg10;
	public bool door04enabled, showmsg3;
	[HideInInspector]
	public bool showmsg4, showmsg6, showmsg9, ispick;
	[HideInInspector]
	public KeyCode key;
	[HideInInspector]
	public int delay, delay_lim;

	// Use this for initialization
	void Start () {
		isbegin = false;
		level2begin = true;
		level3begin = true;
		level2end = true;
		//level3end = true;
		level = 1;
		isBag = false;
		istalking = false;
		showmsg1 = true;
		ispick = true;
		showmsg3 = showmsg4 = showmsg9 = door04enabled =  false;

		key = KeyCode.Q;
		delay_lim = 10;
		delay = 0;

		msg1 = "我很喜欢看漫画，但父母常常把我的漫画书扔掉";
		msg2 = "我似乎听见父母在外面讨论着扔掉漫画书的事情，我必须出去与他们好好谈谈";
		msg3 = "可恶，这个门怎么打不开，再不阻止他们就来不及了";
		msg4 = "门似乎可以打开了，我要赶快找到我的漫画";
		msg5 = "（提示：寻找漫画碎片）";
		msg6 = "太好了，我可以用这些碎片还原出一页漫画了！希望这一页漫画能够为我提供足够的指引，找回我的漫画书";
		msg7 = "让我试试从这一页探寻漫画书的踪迹。（正说着，我便进入了更深层的精神世界）";
		msg8 = "这是什么？一个迷宫？试试能不能在其中找到我的漫画。那就开始寻找吧。（提示：循着太阳的方向）";
		msg9 = "漫画碎片还没找全，先做好手头的事情吧";
		msg10 = "漫画碎片被拾取进了背包中";
	}
	
	// Update is called once per frame
	void Update () {
        if (m_hour >= 0 && m_minute >= 0 && m_second >= 0 && m_millisecond >= 0 && (!istalking) && (isbegin || level2begin || level3begin))
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
        delay += 1;

        string remaintime;
        if (m_hour >= 0 && m_minute >= 0 && m_second >= 0 && m_millisecond >= 0)
            remaintime = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", m_hour, m_minute, m_second, m_millisecond);
        else remaintime = "时间到了！";
        GUI.TextArea(new Rect(Screen.width - 100, 10, 90, 30), remaintime);
        
        //only save progress at start
        if (!isbegin)
            if (GUI.Button(new Rect(Screen.width - 160, 10, 50, 50),"Save"))
            {
                Debug.Log("Save");
                ButtonSet.save_load = 2;
                SceneManager.LoadScene("ContinueGame");
            }

		if (!isbegin) {
			istalking = true;
			string msg;
			if (showmsg1) {
				msg = msg1;
			} else {
				msg = msg2;
			}
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg) 
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				delay = 0;
				if (!showmsg1) {
					isbegin = true;
				} else {
					showmsg1 = false;
				}
				istalking = false;
				Debug.Log("showmsg1 = " + showmsg1.ToString());
			}
		}

		if (showmsg3) {
			istalking = true;
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg3)
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				delay = 0;
				showmsg3 = false;
				istalking = false;
			}
		}

		if (!level2begin) {
			istalking = true;
			string msg;
			if (showmsg4) {
				msg = msg4;
			} else {
				msg = msg5;
			}
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg)
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				delay = 0;
				if (!showmsg4) {
					level2begin = true;
				} else {
					showmsg4 = false;
				}
				istalking = false;
			}
		}

		if (!level2end) {
			istalking = true;
			string msg;
			if (showmsg6) {
				msg = msg6;
			} else {
				msg = msg7;
			}
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg)
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				delay = 0;
				if (!showmsg6) {
					level2end = true;
					ChangeTime(5f);
					GameObject.Find("RigidBodyFPSController").GetComponent<Tragger>().nextLevel();
				} else {
					showmsg6 = false;
				}
				istalking = false;
			}
		}

		if (!level3begin) {
			istalking = true;
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg8)
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				delay = 0;
				level3begin = true;
				istalking = false;
			}
		}

		if (showmsg9) {
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg9)
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				delay = 0;
				showmsg9 = false;
			}
		}

		if (!ispick) {
			if (GUI.Button(new Rect(0, Screen.height - 100, Screen.width, 100), msg10)
				|| (Input.GetKeyDown(key) && delay > delay_lim)) {
				delay = 0;
				ispick = true;
			}
		}

		if (GUI.Button(new Rect(10, 10, 50, 50), "Cross!") || 
			(Input.GetKeyDown(KeyCode.C) && delay > delay_lim ))
		{
			delay = 0;
			Debug.Log("Next Scene");
			
			if (level == 1) {
				ChangeTime(15f);
				door04enabled = true;
				showmsg4 = true;
				level += 1;
				level2begin = false;
				GameObject.Find("RigidBodyFPSController").transform.position = new Vector3(6.5f, 1.5f, 5.2f);
				isbegin = true;
				showmsg3 = false;
			} else if (level == 2) {
				Debug.Log("Attemp to cross in level 2");
				level2begin = true;
				//level2end = true;
				ispick = true;
				if (level2end)
					showmsg9 = true;
			} else if (level == 3) {
				Debug.Log("Attemp to cross in level 3");
			}
		}
		
		if (GUI.Button(new Rect(70, 10, 50, 50), "Bag"))
		{
			Debug.Log("bag");
			isBag = !isBag;
		}

		if (GUI.Button(new Rect(130,10,50,50),"Back"))
		{
			SceneManager.LoadScene("StartScene");
		}
        
        if (isBag)  ShowBag();
        
    }

	private void ShowBag()
    {
        float w = Screen.width / 9;
		Debug.Log("Show Bag");	
		//return;
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
};
