using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MuteCtrl : MonoBehaviour
{
    void Start()
    {
        //画面遷移してもオブジェクトが壊れないようにする
        DontDestroyOnLoad (this);
    }
    void Awake()
    {
        if (PlayerPrefs.GetInt("Mute", 0) == 0)
        {
            AudioListener.volume = 1f;
        } else
        {
            AudioListener.volume = 0f;
        }
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(200,200,200, 80), "ミュートON/OFF"))
        {
            if (PlayerPrefs.GetInt("Mute", 0) == 0)
            {
                AudioListener.volume = 0f;
                PlayerPrefs.SetInt("Mute", 1);
            } else
            {
                AudioListener.volume = 1f;
                PlayerPrefs.SetInt("Mute", 0);
            }
        }
    }
}
