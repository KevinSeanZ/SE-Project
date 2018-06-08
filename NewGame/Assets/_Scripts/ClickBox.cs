using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBox : MonoBehaviour {
    private GameObject mainCamera;
    private GameObject observeCamera;
    public Button[] numberbt = new Button[10];
    public Button ensurebt;
    public Button cancelbt;
    public GameObject fps1;
    private Button observebt;
    private bool isTrigger;
    private Canvas codeboxCanvas;
    private Text codenumbers;
    public bool levelclear = false;

	// Use this for initialization
	void Start () {
        //Attach gameobject to the vars.
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        observeCamera = GameObject.FindGameObjectWithTag("ObserveCamera");
        observebt = GameObject.Find("Canvas/EyeBt").GetComponent<Button>();
        codeboxCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        codenumbers = GameObject.Find("Canvas/CodeNum").GetComponent<Text>();
        fps1.SetActive(true);
        
        //At first, player cannot see the observebt until he gets close enough.
        observebt.gameObject.SetActive(false);
        

        //button clicked
        cancelbt.onClick.AddListener(CancelBt);
        ensurebt.onClick.AddListener(EnsureBt);
        observebt.onClick.AddListener(ObserveBt);
        for (int i = 0; i < 10; i++)
        {
            int tmp = i;
            numberbt[i].onClick.AddListener(delegate () { IthBt(tmp); });
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        isTrigger = fps1.GetComponent<PlayerController>().isTrigger2;
        //Only when current camera is MainCamera, can cancelbt be clicked
        if (mainCamera.GetComponent<Camera>().isActiveAndEnabled)
        {
            cancelbt.enabled = false;
            ensurebt.enabled = false;
            for (int i = 0; i < 10; i++)
                numberbt[i].enabled = false;
        }
        else
        {
            cancelbt.enabled = true;
            ensurebt.enabled = true;
            for (int i = 0; i < 10; i++)
                numberbt[i].enabled = true;
            //Debug.Log("Change Camera!");
        }
        //When player wak close to the code box, player can see the ObserveBt
        if (isTrigger && mainCamera.GetComponent<Camera>().isActiveAndEnabled)
            observebt.gameObject.SetActive(true);
        else observebt.gameObject.SetActive(false);
        
	}
    

    void CancelBt()
    {
        Debug.Log("Cancel!");
        codenumbers.text = "";
    }

    void EnsureBt()
    {
        //Debug.Log("Ensure!");
        if (codenumbers.text == "5421")
        {
            levelclear = true;
            Debug.Log("congratulations!");
        }
        else codenumbers.text = "";
    }

    void IthBt(int i)
    {
        Debug.Log(i);
        if (codenumbers.text.Length < 4) codenumbers.text = codenumbers.text + i.ToString();
    }

    void ObserveBt()
    {
        observeCamera.GetComponent<AudioListener>().enabled = true;
        observeCamera.GetComponent<Camera>().enabled = true;
        mainCamera.GetComponent<AudioListener>().enabled = false;
        mainCamera.GetComponent<Camera>().enabled = false;
        fps1.SetActive(false);
        codeboxCanvas.worldCamera = observeCamera.GetComponent<Camera>();
    }
}
