using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door02 : MonoBehaviour {
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
        door = GameObject.Find("Door02_open");
        door.transform.localPosition = new Vector3(3.77f, 0, 2.68f);
        door.transform.localEulerAngles = new Vector3(-90, 90, 90);
    }
}
