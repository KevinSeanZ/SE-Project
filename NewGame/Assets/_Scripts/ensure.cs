using UnityEngine;
using UnityEngine.UI;//用到了多个UI
using System.Collections;
using System.Collections.Generic;//按钮组将会用到C#的集合
using UnityEngine.SceneManagement;
public class ensure : MonoBehaviour
{


    public void Onclick()
    {
        float volume = GameObject.Find("Canvas/Slider").GetComponent<Slider>().value;

        //接下来将展示按钮组的使用
        int qualityLevel = 1;
        IEnumerable<Toggle> toggleGroup = GameObject.Find("Canvas/ToggleGroup").GetComponent<ToggleGroup>().ActiveToggles();//用于获取按钮组中哪个Toggle被选择
        foreach (Toggle t in toggleGroup)
        {//遍历这个存放Toggle的按钮组IEnumerable，此乃C#的一个枚举集合，一般直接用foreach遍历
            if (t.isOn)//遍历到一个被选择的Toggle
            {
                switch (t.name)//根据这个Toggle的name，我们给string qualityLevel赋予不同的值
                {
                    case "Qualitylevel1":
                        qualityLevel = 1;
                        break;
                    case "Qualitylevel2":
                        qualityLevel = 2;
                        break;
                    case "Qualitylevel3":
                        qualityLevel = 3;
                        break;
                }
                break;//就没必要遍历下去了，后面已经可以预见到，都是没被选择的Toggle。
            }
        }
        

        //用持久化数据PlayerPrefs来存储数据
        //Unity3D对中文支持不好，必须按照擦写一下，才能保存到这个PlayerPrefs里面
        //实质上，PlayerPrefs是一个key-value的键值对，也就是Java中的Map，Python中的Dict，Javascript的Json……就是一个数据字典
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetInt("qualityLevel", qualityLevel);
        SceneManager.LoadScene("StartScene");//切换到主场景
    }

}
