using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFliker : MonoBehaviour {
    public float intensitySmoothTime;
    public float intensityMin;
    public float intensityMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Light>().intensity = Mathf.Lerp(this.gameObject.GetComponent<Light>().intensity, Random.Range(intensityMin, intensityMax), Time.deltaTime * intensitySmoothTime);
	}
}
