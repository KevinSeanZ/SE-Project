using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMove : MonoBehaviour {
    public GameObject followball;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        
        offset = this.transform.position - followball.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = offset + followball.transform.position;
       
	}

    
}
