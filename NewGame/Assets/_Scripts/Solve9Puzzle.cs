using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solve9Puzzle : MonoBehaviour {

    public Button[] puzzlebt = new Button[8];
    public GameObject stair;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 8; i ++)
        {
            int tmp = i;
            puzzlebt[i].onClick.AddListener(delegate () { IthBt(tmp); });
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool IsFinished()
    {
        if (Mathf.Round(puzzlebt[0].transform.localPosition.x) != -1 ||
            Mathf.Round(puzzlebt[0].transform.localPosition.y) != 1) return false;
        if (Mathf.Round(puzzlebt[1].transform.localPosition.x) != 0 ||
            Mathf.Round(puzzlebt[1].transform.localPosition.y) != 1) return false;
        if (Mathf.Round(puzzlebt[2].transform.localPosition.x) != 1 ||
            Mathf.Round(puzzlebt[2].transform.localPosition.y) != 1) return false;
        if (Mathf.Round(puzzlebt[3].transform.localPosition.x) != -1 ||
            Mathf.Round(puzzlebt[3].transform.localPosition.y) != 0) return false;
        if (Mathf.Round(puzzlebt[4].transform.localPosition.x) != 0 ||
            Mathf.Round(puzzlebt[4].transform.localPosition.y) != 0) return false;
        if (Mathf.Round(puzzlebt[5].transform.localPosition.x) != 1 ||
            Mathf.Round(puzzlebt[5].transform.localPosition.y) != 0) return false;
        if (Mathf.Round(puzzlebt[6].transform.localPosition.x) != -1 ||
            Mathf.Round(puzzlebt[6].transform.localPosition.y) != -1) return false;
        if (Mathf.Round(puzzlebt[7].transform.localPosition.x) != 1 ||
            Mathf.Round(puzzlebt[7].transform.localPosition.y) != -1) return false;
        return true;
    }

    void IthBt(int t)
    {
        //float x = puzzlebt[t].transform.position.x;
        float x = puzzlebt[t].transform.localPosition.x;
        float y = puzzlebt[t].transform.localPosition.y;
        float z = puzzlebt[t].transform.localPosition.z;
        float[] x_plus = { 0, 1, 0, -1 };
        float[] y_plus = { 1, 0, -1, 0 };
        bool isempty;
        
        for (int i = 0; i < 4; i++)
            if (Mathf.Round(x + x_plus[i]) < 2 && Mathf.Round(x + x_plus[i]) > -2 && 
                Mathf.Round(y + y_plus[i]) < 2 && Mathf.Round(y + y_plus[i]) > -2)
            {
                isempty = true;
                
                for (int j = 0; j < 8; j++)
                    if (Mathf.Abs(puzzlebt[j].transform.localPosition.x - x - x_plus[i])<0.01 &&
                        Mathf.Abs(puzzlebt[j].transform.localPosition.y - y - y_plus[i])<0.01)
                    {
                        isempty = false;
                        
                        break;
                        
                    }
                
                if (isempty)
                {
                    x = x + x_plus[i];
                    y = y + y_plus[i];
                    puzzlebt[t].transform.localPosition = new Vector3(x, y, z);
                    //puzzlebt[t].transform.SetPositionAndRotation(new Vector3(x, y, z),puzzlebt[t].transform.rotation);
                    break;
                }
            }
        if (IsFinished())
        {
            for (int i = 0; i < 8; i++)
                puzzlebt[i].enabled = false;
            Debug.Log("Congratulations!");
            stair.SetActive(true);

        }
    }
}
