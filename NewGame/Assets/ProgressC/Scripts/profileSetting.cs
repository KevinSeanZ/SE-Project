using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class profileSetting : MonoBehaviour {

    public GameObject saveProfile;
    public GameObject loadProfile;

    private Button bt1;
    private Button bt2;
    private Button bt3;
    //其他场景切换到这个场景的时候，要更新这两个值
    //如果是游戏中的save Button过来的，传当前关卡给currentLevel,(1,2,3分别对应第几关），传0给save_or_load；
    //如果是游戏主面板读取存档过来的，不用传currentlevel（或者随便给个值），传1给save_or_load
    private int currentLevel;
    public int save_or_load;

    public int Profile1_used;
    public int Profile2_used;
    public int Profile3_used;

    // Use this for initialization
    void Start () {
        //更新 save_or_load 的值，等于i，保存界面，保存第i关，等于0，读取界面
        //button_set = GameObject.Find("Canvas").GetComponent<ButtonSet>();
        save_or_load = ButtonSet.save_load;
        if (save_or_load != 0)
        {
            ActiveSavePanel();
            Debug.Log("From Stage" + save_or_load);
        }
        else
        {
            ActiveLoadPanel();
            Debug.Log("from start");
        }

        Profile1_used = PlayerPrefs.GetInt("Profile1_used", 0);
        Profile2_used = PlayerPrefs.GetInt("Profile2_used", 0);
        Profile3_used = PlayerPrefs.GetInt("Profile3_used", 0);

        if (loadProfile.active)
        {
            bt1 = GameObject.Find("Canvas/WindowProfile/LoadProfile/Grid/Button1").GetComponent<Button>();
            bt2 = GameObject.Find("Canvas/WindowProfile/LoadProfile/Grid/Button2").GetComponent<Button>();
            bt3 = GameObject.Find("Canvas/WindowProfile/LoadProfile/Grid/Button3").GetComponent<Button>();
            bt1.onClick.AddListener(profile_1_load);
            bt2.onClick.AddListener(profile_2_load);
            bt3.onClick.AddListener(profile_3_load);
            Debug.Log(111111);
        }
        else
        {
            bt1 = GameObject.Find("Canvas/WindowProfile/SaveProfile/Grid/Button1").GetComponent<Button>();
            bt2 = GameObject.Find("Canvas/WindowProfile/SaveProfile/Grid/Button2").GetComponent<Button>();
            bt3 = GameObject.Find("Canvas/WindowProfile/SaveProfile/Grid/Button3").GetComponent<Button>();

            Debug.Log(2222222);
            bt1.onClick.AddListener(profile_1_save);
            bt2.onClick.AddListener(profile_2_save);
            bt3.onClick.AddListener(profile_3_save);
        }

        if (Profile1_used == 1) bt1.GetComponentInChildren<Text>().text = "<存档1>";
        else bt1.GetComponentInChildren<Text>().text = "<无存档>";
        if (Profile2_used == 1) bt2.GetComponentInChildren<Text>().text = "<存档2>";
        else bt2.GetComponentInChildren<Text>().text = "<无存档>";
        if (Profile3_used == 1) bt3.GetComponentInChildren<Text>().text = "<存档3>";
        else bt3.GetComponentInChildren<Text>().text = "<无存档>";


    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //启用保存界面，禁用读取界面
    public void ActiveSavePanel()
    {
        saveProfile.SetActive(true);
        loadProfile.SetActive(false);
    }

    //启用读取界面，禁用保存界面
    public void ActiveLoadPanel()
    {
        saveProfile.SetActive(false);
        loadProfile.SetActive(true);
    }

    //读取当前进度，scene0表示这个存档scene，scene1,2,3分别代表1，2，3关
    public void profile_1_load()
    {

        currentLevel = PlayerPrefs.GetInt("Profile1", 0);
        if (currentLevel == 0) SceneManager.LoadScene("scene0");
        if (currentLevel == 1) SceneManager.LoadScene("Stage_1_Scene_1");
        if (currentLevel == 2) SceneManager.LoadScene("SampleScene");
        if (currentLevel == 3) SceneManager.LoadScene("scene3");
    }

    public void profile_1_save()
    {
        //当前游戏进度保存到currentlevel
        PlayerPrefs.SetInt("Profile1", save_or_load);
        PlayerPrefs.SetInt("Profile1_used", 1);
        if (Profile1_used == 0) bt1.GetComponentInChildren<Text>().text = "<存档1>";
        Debug.Log("Save Successfully");
        if (save_or_load == 1)
        {
            //GameObject.Find("Canvas/WindowProfile/LoadProfile/Grid/Button1/Text").GetComponent<Text>().text = "stage 1";
            //GameObject.Find("Canvas/WindowProfile/SaveProfile/Grid/Button1/Text").GetComponent<Text>().text = "stage 1";
            bt1.GetComponentInChildren<Text>().text = "";
            SceneManager.LoadScene("Stage_1_Scene_1");
           
        }

        if (save_or_load == 2)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void profile_2_load()
    {
        currentLevel = PlayerPrefs.GetInt("Profile2", 0);
        if (currentLevel == 0) SceneManager.LoadScene("scene0");
        if (currentLevel == 1) SceneManager.LoadScene("Stage_1_Scene_1");
        if (currentLevel == 2) SceneManager.LoadScene("SampleScene");
        if (currentLevel == 3) SceneManager.LoadScene("scene3");
    }

    public void profile_2_save()
    {
        //当前游戏进度保存到currentlevel
        PlayerPrefs.SetInt("Profile2", save_or_load);
        PlayerPrefs.SetInt("Profile2_used", 1);
        if (Profile2_used == 0) bt2.GetComponentInChildren<Text>().text = "<存档2>";
        if (save_or_load == 1)
        {
            //GameObject.Find("Canvas/WindowProfile/LoadProfile/Grid/Button2/Text").GetComponent<Text>().text = "stage 1";
            //GameObject.Find("Canvas/WindowProfile/SaveProfile/Grid/Button2/Text").GetComponent<Text>().text = "stage 1";
            SceneManager.LoadScene("Stage_1_Scene_1");

        }
        if (save_or_load == 2)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    public void profile_3_load()
    {
        currentLevel = PlayerPrefs.GetInt("Profile3", 0);
        if (currentLevel == 0) SceneManager.LoadScene("scene0");
        if (currentLevel == 1) SceneManager.LoadScene("Stage_1_Scene_1");
        if (currentLevel == 2) SceneManager.LoadScene("SampleScene");
        if (currentLevel == 3) SceneManager.LoadScene("scene3");
    }

    public void profile_3_save()
    {
        //当前游戏进度保存到currentlevel
        PlayerPrefs.SetInt("Profile1", save_or_load);
        PlayerPrefs.SetInt("Profile3_used", 1);
        if (Profile3_used == 0) bt3.GetComponentInChildren<Text>().text = "<存档3>";
        if (save_or_load == 1)
        {
            //GameObject.Find("Canvas/WindowProfile/LoadProfile/Grid/Button2/Text").GetComponent<Text>().text = "stage 1";
            //GameObject.Find("Canvas/WindowProfile/SaveProfile/Grid/Button2/Text").GetComponent<Text>().text = "stage 1";
            SceneManager.LoadScene("Stage_1_Scene_1");

        }
        if (save_or_load == 2)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
