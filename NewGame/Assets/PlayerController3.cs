using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour {

    public bool istrigger2 = false;
    public GameObject observediarybt;
    //public GameObject probcanvas;
    // Use this for initialization
    void Start()
    {
        //probcanvas = GameObject.Find("level1s3/Canvas");
        observediarybt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //probcanvas = GameObject.Find("level1s3/Canvas");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "trigger1")
        {
            
            Debug.Log("trigger1 enter");
            collider.gameObject.SetActive(false);
        }
        else if (collider.tag == "trigger2")
        {
            Debug.Log("trigger2 enter");
            //istrigger2 = true;
            observediarybt.SetActive(true);
            //probcanvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "trigger2")
        {
            observediarybt.SetActive(false);
            Debug.Log("trigger2 exit");
            istrigger2 = false;
        }
    }
}



