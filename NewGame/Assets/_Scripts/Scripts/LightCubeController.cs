using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCubeController : MonoBehaviour {

	public Material mat_red;
	public Material mat_blue;
	public Material mat_green;
	private MeshRenderer renderer_this;

	// Use this for initialization
	void Start () {
		renderer_this = GetComponent<MeshRenderer>();
		Debug.Log(renderer_this.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setMaterial (int mat_ind) {
		//Debug.Log(renderer_this.name);
		if (mat_ind == 1) {
			renderer_this.material = mat_red;
		} else if (mat_ind == 2) {
			renderer_this.material = mat_blue;
		} else if (mat_ind == 3) {
			renderer_this.material = mat_green;
		} else {
			Debug.Log("[warninig] unknown material index in Light Cube Controller");
		}
	}
}
