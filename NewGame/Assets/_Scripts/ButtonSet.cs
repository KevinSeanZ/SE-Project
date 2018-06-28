using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ButtonSet : MonoBehaviour {

    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphere3;

    private Button begingamebt;
    private Button settingbt;
    private Button continuebt;
    private Button exitbt;
    // Use this for initialization
    
    [HideInInspector]
    public static int save_load;

    void Start() {

        begingamebt = GameObject.Find("Canvas/BeginGameBt").GetComponent<Button>();
        settingbt = GameObject.Find("Canvas/GameSetBt").GetComponent<Button>();
        continuebt = GameObject.Find("Canvas/ContinueGameBt").GetComponent<Button>();
        exitbt = GameObject.Find("Canvas/ExitGameBt").GetComponent<Button>();

        begingamebt.onClick.AddListener(BeginNewGame);
        settingbt.onClick.AddListener(SetGame);
        exitbt.onClick.AddListener(ExitGame);
        continuebt.onClick.AddListener(ConGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void  BeginNewGame()
    {
        SceneManager.LoadScene("Stage_1_Scene_1");
    }

    void ExitGame()
    {
        Application.Quit();
    }
   
    void SetGame()
    {

        
        SceneManager.LoadScene("GUI_settings",LoadSceneMode.Single);
    }

    void ConGame()
    {
        save_load = 0;
        SceneManager.LoadScene("ContinueGame");
    }
}
