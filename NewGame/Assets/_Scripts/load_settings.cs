using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class load_settings : MonoBehaviour {
    public AudioSource asound;
    public int qualityLevel;
    // Use this for initialization
    void Start () {
		asound.volume = PlayerPrefs.GetFloat("volume");
        qualityLevel = PlayerPrefs.GetInt("qualityLevel");
        QualitySettings.SetQualityLevel(qualityLevel, true);
        Debug.Log("qualityLevel" + qualityLevel.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
