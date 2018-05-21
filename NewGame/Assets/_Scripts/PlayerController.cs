using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    //public Button testButton;
    // Use this for initialization
    public bool isTrigger2 = false;
    
	void Start () {
        
        //testButton.onClick.AddListener(ClickTest);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "TriggerArea1")
        {
            Debug.Log("12345678");
            collider.gameObject.SetActive(false);
        }
        if (collider.tag == "TriggerArea2")
        {
            Debug.Log("87654321");
            isTrigger2 = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        
        if (collider.tag == "TriggerArea2")
        {
            Debug.Log("asdfghjkl");
            isTrigger2 = false;
        }
    }

}
