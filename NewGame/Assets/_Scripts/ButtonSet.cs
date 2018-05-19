using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSet : MonoBehaviour {
    
    private Button begingamebt;
    
	// Use this for initialization
	void Start () {
            
        begingamebt = GameObject.Find("Canvas/BeginGameBt").GetComponent<Button>();
        
        begingamebt.onClick.AddListener(BeginNewGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void  BeginNewGame()
    {
        SceneManager.LoadScene("Stage_1_Scene_1");
    }
}
