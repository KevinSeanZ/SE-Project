using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door03 : MonoBehaviour {

    GameObject door;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        door = GameObject.Find("Door03_open");
        door.transform.localPosition = new Vector3(-4.43f, 0, -4.85f);
        door.transform.localEulerAngles = new Vector3(-90, 0, 90);
    }
}
