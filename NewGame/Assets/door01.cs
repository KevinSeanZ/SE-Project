using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door01 : MonoBehaviour {

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
        door = GameObject.Find("AnimationDoor01");
        door.transform.localPosition = new Vector3(7.54f, 0, -4.02f);
        door.transform.localEulerAngles = new Vector3(-90, 180, 130);
    }
}
