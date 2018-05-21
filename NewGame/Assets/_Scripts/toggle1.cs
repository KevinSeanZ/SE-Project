using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle1 : MonoBehaviour {


    public void Sel_toggle(bool Selete)
    {

        if (Selete)
        {

            QualitySettings.SetQualityLevel(2, true);

        }
        

    }
}
