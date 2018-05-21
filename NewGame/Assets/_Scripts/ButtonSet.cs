using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSet : MonoBehaviour {
    
    private Button begingamebt;
    private Button settingbt;
    // Use this for initialization
    void Start() {

        begingamebt = GameObject.Find("Canvas/BeginGameBt").GetComponent<Button>();
        settingbt = GameObject.Find("Canvas/GameSetBt").GetComponent<Button>();
        begingamebt.onClick.AddListener(BeginNewGame);
        settingbt.onClick.AddListener(SetGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void  BeginNewGame()
    {
        SceneManager.LoadScene("Stage_1_Scene_1");
    }

    void SetGame()
    {
        SceneManager.LoadScene("GUI_settings");
    }
}
