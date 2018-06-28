using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door04 : MonoBehaviour {

    GameObject door;
    private bool door04enabled;
    private MainCanvasSet2 ms;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!ms) {
            ms = GameObject.Find("MainCanvas").GetComponent<MainCanvasSet2>();
        }
        door04enabled = ms.door04enabled;
        if (door04enabled) {
            door = GameObject.Find("Door04_open");
            door.transform.localPosition = new Vector3(6.74f, 0, 1.26f);
            door.transform.localEulerAngles = new Vector3(-90, 0, 0);
        } else {
            ms.showmsg3 = true;
        }
    }
}
