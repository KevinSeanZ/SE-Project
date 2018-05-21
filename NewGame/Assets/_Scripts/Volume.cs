using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    public AudioSource asound;
    public Slider sd;
    // Use this for initialization
    void Start () {
        //读取存档进行初始化
        asound.volume = PlayerPrefs.GetFloat("volume");
        sd.value = asound.volume;
    }
	

    public void Con_sound()
    {
        asound.volume = sd.value;
    }
}
